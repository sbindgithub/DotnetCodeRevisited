# DDoS (Distributed Denial of Service)

## Goal

Exhaust resources → make service unavailable.

## Types

* Volumetric (traffic flood)
* Protocol (SYN flood)
* Application layer (HTTP flood)

## Defense

* CDN/WAF (Cloudflare, Front Door)
* Load balancing
* Rate limiting (app-level)

## .NET Role

* Rate limiting
* Caching
* Resilience (Polly)

## Interview Line

“Primary defense is at edge (CDN/WAF); app provides secondary controls.”
