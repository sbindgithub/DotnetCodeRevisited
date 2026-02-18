let state = {
    startDate: "",
    days: []
};

const predefinedDays = [
    // Week 1
    { topic: "Advanced C# Internals + CLR", deliverable: "Explain struct vs class trade-offs" },
    { topic: "Garbage Collector Internals", deliverable: "Explain GC generations clearly" },
    { topic: "Async/Await Internals", deliverable: "Demonstrate deadlock scenario" },
    { topic: "Dependency Injection Mastery", deliverable: "Explain captive dependency" },
    { topic: "LINQ + EF Core Query Pipeline", deliverable: "Explain IQueryable danger" },
    { topic: "EF Core Deep Internals", deliverable: "Explain DbContext lifecycle" },
    { topic: "Clean Architecture + SOLID", deliverable: "Explain dependency rule" },

    // Week 2
    { topic: "Microservices vs Modular Monolith", deliverable: "Defend architecture choice" },
    { topic: "Kafka vs RabbitMQ", deliverable: "Explain consumer groups" },
    { topic: "Outbox Pattern", deliverable: "Implement transactional outbox" },
    { topic: "Caching + Redis", deliverable: "Explain thundering herd problem" },
    { topic: "Design Patterns Tradeoffs", deliverable: "Explain when NOT to use CQRS" },
    { topic: "Concurrency + Multithreading", deliverable: "Explain lock vs Interlocked" },
    { topic: "Distributed Systems + CAP", deliverable: "Place systems on CAP diagram" },

    // Week 3
    { topic: "Azure App Service vs AKS", deliverable: "Defend service choice" },
    { topic: "Azure Monitoring + Observability", deliverable: "Explain distributed tracing" },
    { topic: "OAuth2 + JWT Internals", deliverable: "Explain PKCE properly" },
    { topic: "API Design + Versioning", deliverable: "Defend versioning strategy" },
    { topic: "SQL Optimization", deliverable: "Explain SARGability" },
    { topic: "Performance Profiling", deliverable: "Identify allocation hotspot" },
    { topic: "CI/CD Architecture", deliverable: "Design full pipeline" },

    // Week 4
    { topic: "System Design 1–3", deliverable: "Use ARCH framework" },
    { topic: "System Design 4–6", deliverable: "Explain trade-offs deeply" },
    { topic: "System Design 7–10", deliverable: "Master logistics design" },
    { topic: "Decision Articulation", deliverable: "Use Context→Decision→Tradeoff" },
    { topic: "Behavioral Stories", deliverable: "Prepare 10 STAR stories" },
    { topic: "Mock Interview #1", deliverable: "Score yourself 38+/50" },
    { topic: "Mock Interview #2 + Final Review", deliverable: "Score 40+/50" }
];


async function loadState() {
    const response = await fetch("/progress");
    const xmlText = await response.text();

    if (!xmlText || xmlText.trim() === "<Plan startDate=\"\"></Plan>") {
        initializeState();
        await saveState();
    } else {
        parseXML(xmlText);
    }

    render();
}

function initializeState() {
    state.days = predefinedDays.map((d, index) => ({
        number: index + 1,
        date: "",
        completed: false,
        topic: d.topic,
        deliverable: d.deliverable
    }));
}

function generateDates() {
    const start = document.getElementById("startDate").value;
    state.startDate = start;

    const base = new Date(start);

    state.days.forEach((d, i) => {
        const newDate = new Date(base);
        newDate.setDate(base.getDate() + i);
        d.date = newDate.toISOString().split("T")[0];
    });

    saveState();
    render();
}

function render() {
    const container = document.getElementById("daysContainer");
    container.innerHTML = "";

    const weeks = [
        { id: "week1", start: 1, end: 7 },
        { id: "week2", start: 8, end: 14 },
        { id: "week3", start: 15, end: 21 },
        { id: "week4", start: 22, end: 30 }
    ];

    weeks.forEach(week => {
        const section = document.createElement("div");
        section.id = week.id;

        const heading = document.createElement("h2");
        heading.textContent = week.id.toUpperCase();
        section.appendChild(heading);

        state.days
            .filter(d => d.number >= week.start && d.number <= week.end)
            .forEach(day => {
                const div = document.createElement("div");
                div.className = "day-card " + (day.completed ? "completed" : "");

                div.innerHTML = `
                    <h3>Day ${day.number}</h3>
                    <p><strong>Date:</strong> ${day.date || "Not Set"}</p>
                    <p><strong>Topic:</strong> ${day.topic}</p>
                    <p><strong>Deliverable:</strong> ${day.deliverable}</p>
                    <input type="checkbox" ${day.completed ? "checked" : ""}
                        onchange="toggleDay(${day.number})"> Mark Complete
                `;

                section.appendChild(div);
            });

        container.appendChild(section);
    });
}


function toggleDay(dayNumber) {
    const day = state.days.find(d => d.number === dayNumber);
    day.completed = !day.completed;
    saveState();
    render();
}

async function saveState() {
    const xml = buildXML();
    await fetch("/progress", {
        method: "POST",
        headers: { "Content-Type": "application/xml" },
        body: xml
    });
}

function buildXML() {
    let xml = `<Plan startDate="${state.startDate}">`;

    state.days.forEach(d => {
        xml += `
        <Day number="${d.number}" date="${d.date}" completed="${d.completed}">
            <Topic>${escapeXml(d.topic)}</Topic>
            <Deliverable>${escapeXml(d.deliverable)}</Deliverable>
        </Day>`;
    });

    xml += `</Plan>`;
    return xml;
}

function parseXML(xmlText) {
    const parser = new DOMParser();
    const xml = parser.parseFromString(xmlText, "text/xml");

    const plan = xml.getElementsByTagName("Plan")[0];
    state.startDate = plan.getAttribute("startDate") || "";

    const dayNodes = xml.getElementsByTagName("Day");

    state.days = [];

    for (let i = 0; i < dayNodes.length; i++) {
        state.days.push({
            number: parseInt(dayNodes[i].getAttribute("number")),
            date: dayNodes[i].getAttribute("date"),
            completed: dayNodes[i].getAttribute("completed") === "true",
            topic: dayNodes[i].getElementsByTagName("Topic")[0].textContent,
            deliverable: dayNodes[i].getElementsByTagName("Deliverable")[0].textContent
        });
    }
}

function escapeXml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&apos;");
}

loadState();
