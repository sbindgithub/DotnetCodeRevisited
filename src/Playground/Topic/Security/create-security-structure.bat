@echo off

cd Domain\Security

:: Fundamentals
mkdir Fundamentals
cd Fundamentals
type nul > CIA_Triad.md
type nul > ZeroTrust.md
type nul > DefenseInDepth.md
type nul > ThreatModeling.md
type nul > OWASP_Top10.md
cd ..

:: Cryptography
mkdir Cryptography
cd Cryptography
mkdir Hashing Encryption KeyManagement

cd Hashing
type nul > PBKDF2.md
type nul > BCrypt.md
type nul > Argon2.md
cd ..

cd Encryption
type nul > AES.md
type nul > RSA.md
cd ..

cd KeyManagement
type nul > KeyRotation.md
type nul > HSM.md
cd ..
cd ..

:: Identity
mkdir Identity
cd Identity
mkdir Authentication Authorization IdentityProviders

cd Authentication
type nul > Cookies.md
type nul > JWT.md
type nul > OAuth2.md
type nul > OpenIDConnect.md
type nul > MFA.md
cd ..

cd Authorization
type nul > RBAC.md
type nul > ABAC.md
type nul > PolicyBased.md
cd ..

cd IdentityProviders
type nul > ASPNETIdentity.md
type nul > AzureAD.md
type nul > IdentityServer.md
cd ..
cd ..

:: ApplicationSecurity
mkdir ApplicationSecurity
cd ApplicationSecurity
type nul > InputValidation.md
type nul > OutputEncoding.md
type nul > XSS.md
type nul > CSRF.md
type nul > SQLInjection.md
type nul > SSRF.md
type nul > CORS.md
type nul > SecureHeaders.md
type nul > FileUploadSecurity.md
cd ..

:: DataSecurity
mkdir DataSecurity
cd DataSecurity
type nul > EncryptionAtRest.md
type nul > EncryptionInTransit.md
type nul > DataMasking.md
type nul > PII_Handling.md
type nul > SecureStorage.md
cd ..

:: InfrastructureSecurity
mkdir InfrastructureSecurity
cd InfrastructureSecurity
mkdir NetworkSecurity TransportSecurity Attacks Defenses

cd NetworkSecurity
type nul > Firewalls.md
type nul > VPC_VNet.md
type nul > Subnets.md
cd ..

cd TransportSecurity
type nul > HTTPS_TLS.md
type nul > Certificates.md
cd ..

cd Attacks
type nul > DDoS.md
type nul > SYN_Flood.md
type nul > MITM.md
cd ..

cd Defenses
type nul > WAF.md
type nul > CDN.md
type nul > LoadBalancing.md
type nul > TrafficFiltering.md
cd ..
cd ..

:: CloudSecurity
mkdir CloudSecurity
cd CloudSecurity
type nul > SharedResponsibilityModel.md
type nul > IAM.md
type nul > SecretsManagement.md
type nul > KeyVault.md
type nul > ManagedIdentity.md
cd ..

:: Attacks
mkdir Attacks
cd Attacks
mkdir CredentialAttacks WebAttacks SupplyChain

cd CredentialAttacks
type nul > RainbowTable.md
type nul > BruteForce.md
type nul > CredentialStuffing.md
cd ..

cd WebAttacks
type nul > XSS.md
type nul > CSRF.md
type nul > SQLInjection.md
cd ..

cd SupplyChain
type nul > DependencyConfusion.md
type nul > MaliciousPackages.md
cd ..
cd ..

:: Defenses
mkdir Defenses
cd Defenses
mkdir PasswordSecurity APIProtection SecureConfiguration

cd PasswordSecurity
type nul > HashingWithSalt.md
type nul > KeyStretching.md
cd ..

cd APIProtection
type nul > RateLimiting.md
type nul > Throttling.md
cd ..

cd SecureConfiguration
type nul > EnvironmentVariables.md
type nul > SecretRotation.md
cd ..
cd ..

:: ObservabilitySecurity
mkdir ObservabilitySecurity
cd ObservabilitySecurity
type nul > AuditLogging.md
type nul > SIEM.md
type nul > Alerting.md
cd ..

:: SecureSDLC
mkdir SecureSDLC
cd SecureSDLC
type nul > CodeReview.md
type nul > StaticAnalysis.md
type nul > DependencyScanning.md
type nul > ThreatModelingProcess.md
cd ..

:: Compliance
mkdir Compliance
cd Compliance
type nul > GDPR.md
type nul > ISO27001.md
type nul > SOC2.md
cd ..

:: DotNetImplementation
mkdir DotNetImplementation
cd DotNetImplementation
mkdir ASPNETCore Libraries

cd ASPNETCore
mkdir Middleware

cd Middleware
type nul > Authentication.md
type nul > Authorization.md
type nul > RateLimiting.md
cd ..

type nul > DataProtectionAPI.md
type nul > IdentityIntegration.md
cd ..

cd Libraries
type nul > MicrosoftIdentity.md
type nul > SerilogSecurity.md
type nul > PollyResilience.md
cd ..

echo Structure created successfully.
pause