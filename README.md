r2dr2-udp-drdos-tool
====================

UDP amplification DRDoS tool (BETA)

A simple application to create a DRDoS UDP Amplification attack.


Requirements
-----

- .NET Framework v4.5
- WinPcap v4.1.3
- Not be on a network with active BCP 38 ingress filtering (only if you want to spoof a public IP).

Usage
-----
- Configure and load the JSON config file (see the examples).
- Select the interface you want to use.
- Click on "Empezar" button.


Todo
----
- Translate to English.
- Templating system on payload hex.
- Check all currently vulnerable protocols. 
- «Real» verification by using two machines (one spoofing packets to the other).
- Suggestions?

Changelog
--------
- 2014-06-23: 
  - First release, not well debugged. BETA.
