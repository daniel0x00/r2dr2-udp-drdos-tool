r2dr2-udp-drdos-tool
====================

UDP amplification DRDoS tool (BETA)

A simple application to create a DRDoS UDP Amplification attacks.

Features
-----
- Allow IP Spoofing of public src address. 
- Allow exploiting of multiples services by introducing hex payloads. Proven compatibility with protocols: Citrix ICA, SIP, NTP, CharGEN.
- Allow configurable multi-threading system.
- Allow pivoting system on the same binary (opening 9000/udp port).

Please read a review (with example video) of this project on:
- Spanish: http://www.securitybydefault.com/2014/06/r2dr2-analisis-y-explotacion-de.html
- English: http://www.securitybydefault.com/2014/06/r2dr2-analysis-and-exploitation-of-udp-amplification-vulns.html

Requirements
-----

- .NET Framework v4.5.1 (older versions can cause a crash)
- WinPcap v4.1.3
- Not be on a network with active BCP 38 ingress filtering (only if you want to spoof a public IP).
- 64 bits OS.

Usage
-----
- Configure and load the JSON config file (see the examples on Binary folder).
- Select the interface you want to use.
- Click on "Empezar" button.


Todo
----
- Translate to English.
- Templating system on hex payload.
- Check all currently vulnerable protocols. 
- Configurable auto minimized window. 
- Suggestions?

Changelog
--------
- 2014-06-23: 
  - First release, not well debugged. BETA.
