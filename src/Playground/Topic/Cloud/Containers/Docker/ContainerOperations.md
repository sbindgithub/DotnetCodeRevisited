# Docker Container Operations

## 1. Long Running Container

A container runs as long as its main process is running.

✔ Long-running example:
- nginx
- dotnet web api

```bash
docker run -d nginx
````

❌ Short-lived example:

* hello-world (runs and exits)

---

## 2. Detached Mode (-d)

Runs container in background

```bash
docker run -d nginx
```

* Terminal is free
* Container keeps running

Without -d:

* Runs in foreground
* Terminal gets locked

---

## 3. docker pull vs docker run

### docker pull

* Only downloads image
* Does NOT start container

```bash
docker pull nginx
```

---

### docker run

* Pulls image (if not exists)
* Creates container
* Starts container

```bash
docker run nginx
```

✔ `run = pull + create + start`

---

## 4. docker ps vs docker ps -a

### docker ps

Shows only running containers

```bash
docker ps
```

---

### docker ps -a

Shows all containers:

* Running
* Stopped
* Exited

```bash
docker ps -a
```

---

## 5. Port Mapping

Maps host port → container port

```bash
docker run -d -p 8081:80 nginx
```

Meaning:

* Access app via: [http://localhost:8081](http://localhost:8081)
* Container runs on port 80

Flow:
Client → localhost:8081 → container:80

---

## 6. Container Lifecycle Commands

### Stop container

```bash
docker stop <container-id>
```

Gracefully stops

---

### Start container

```bash
docker start <container-id>
```

Starts stopped container

---

### Restart container

```bash
docker restart <container-id>
```

Stop + Start

---

## 7. Logs

View container logs

```bash
docker logs <container-id>
```

Follow logs (live):

```bash
docker logs -f <container-id>
```

---

## 8. Remove Containers

```bash
docker rm <container-id>
```

⚠️ Must be stopped first

---

## 9. Remove Images

```bash
docker rmi <image-name>
```

⚠️ Cannot remove if container exists

---

## 10. Cleanup Commands

### Remove all stopped containers

```bash
docker container prune
```

---

### Remove unused images

```bash
docker image prune
```

---

## 11. Real Understanding (Critical)

### Q1: Why nginx keeps running but hello-world exits?

* nginx → long-running process (web server)
* hello-world → one-time execution

---

### Q2: Why port mapping needed?

* Containers are isolated
* Host cannot access container directly

---

### Q3: Why use detached mode?

* Run services in background
* Free terminal

---

## 12. Common Mistakes

* Forgetting port mapping → cannot access app
* Running without -d → terminal blocked
* Not checking logs → blind debugging
* Not cleaning containers → disk usage grows

---

## 13. Summary

* pull → download
* run → create + start
* ps → running
* ps -a → all
* -d → background
* -p → port mapping

Docker = process lifecycle + isolation + networking

````

---

## 🔥 What You Must Now Be Able to Explain

From your screenshots + commands:

If I ask:

> “Why is your container not accessible in browser?”

You should immediately check:
- Port mapping (`-p`)
- Container running (`docker ps`)
- Logs (`docker logs`)

---

## 🎯 Next Step

Create:

```text
Cloud/Containers/Docker/DockerCompose.md
````

Then move from:

* Single container → multi-container system

(API + DB + Redis)

---

next,

👉 A **real .NET + SQL Docker Compose setup**
and test your understanding like a system design discussion.
