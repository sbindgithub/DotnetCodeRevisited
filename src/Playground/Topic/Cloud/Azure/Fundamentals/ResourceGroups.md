## 📄 ResourceGroups.md

### 1. What is a Resource Group

* Logical container for Azure resources
* Used to **organize, manage, and control lifecycle** of related resources
* Every resource **must belong to exactly one resource group**

---

### 2. Key Characteristics

* Resources in a group can be:

  * Different types (VM, DB, Storage, etc.)
  * Different regions (allowed, but not recommended blindly)

* Resource group has:

  * Location (metadata location, not resource location)
  * RBAC scope
  * Tagging scope

---

### 3. Purpose

* Logical grouping
* Access control (RBAC)
* Lifecycle management (create/delete together)
* Cost tracking (via tags)

---

### 4. Resource Group vs Subscription

| Aspect    | Resource Group     | Subscription                |
| --------- | ------------------ | --------------------------- |
| Scope     | Logical grouping   | Billing + security boundary |
| Isolation | Limited            | Strong                      |
| Usage     | Organize resources | Separate environments       |

---

### 5. Design Strategies (Critical)

#### 5.1 By Application (Recommended)

```text
RG-OrderApp-Prod
   ├── App Service
   ├── Azure SQL
   ├── Storage
```

✔ Easy lifecycle management
✔ Clear ownership

---

#### 5.2 By Environment

```text
RG-Prod
RG-Dev
RG-Test
```

✔ Simple
❌ Becomes messy at scale

---

#### 5.3 Hybrid (Best Practice)

```text
RG-OrderApp-Prod
RG-OrderApp-Dev
RG-Payment-Prod
```

✔ Combines clarity + control

---

### 6. Lifecycle Management

* Deleting a resource group → deletes **all resources inside**
* Useful for:

  * Test environments
  * Temporary deployments

⚠️ Risk:

* Accidental deletion = full system outage

---

### 7. Access Control (RBAC)

* Roles can be assigned at:

  * Resource Group level
* Common roles:

  * Owner
  * Contributor
  * Reader

**Best Practice**

* Avoid giving Owner at subscription level
* Assign least privilege at RG level

---

### 8. Tagging Strategy

Example:

```text
Environment = Prod
Project = OrderSystem
Owner = Sarada
CostCenter = Logistics
```

Used for:

* Cost tracking
* Governance
* Reporting

---

### 9. Real-World Scenario

#### Scenario: Microservices System

You have:

* Order Service
* Payment Service
* Notification Service

Design:

```text
RG-Order-Prod
RG-Payment-Prod
RG-Notification-Prod
```

Why:

* Independent deployment
* Failure isolation
* Clear ownership

---

### 10. Common Mistakes

* Putting everything in one RG
* Mixing Prod and Dev in same RG
* No tagging strategy
* Ignoring RBAC

---

### 11. Interview-Level Questions You Must Handle

#### Q1:

> Can resources in a resource group be in different regions?

✔ Yes
But:

* Avoid unless required (latency, management complexity)

---

#### Q2:

> What happens when you delete a resource group?

✔ All resources are deleted permanently

---

#### Q3:

> Why not use one resource group per subscription?

✔ No isolation
✔ Hard to manage at scale
✔ No lifecycle separation

---

## 🔥 Your Next Step

Add this section yourself:

### 👉 “When NOT to use same Resource Group”

You should include:

* Cross-team ownership
* Different lifecycle
* Security boundaries

---

