@echo =========  SQL Server Ports  =================== 
netsh firewall set portopening TCP 1433 "SQLServer" 
netsh firewall set portopening TCP 1434 "SQL Admin Connection" 
netsh firewall set portopening TCP 4022 "SQL Service Broker" 
netsh firewall set portopening TCP 135 "SQL Debugger/RPC" 
netsh firewall set portopening TCP 2383 "Analysis Services" 
netsh firewall set portopening TCP 2382 "SQL Browser" 
netsh firewall set portopening TCP 80 "HTTP" 
netsh firewall set portopening TCP 443 "SSL" 
netsh firewall set portopening UDP 1434 "SQL Browser" 
netsh firewall set multicastbroadcastresponse ENABLE