## Windows Service for Website status monitoring      
1. Open PowerShell as Administrator.
2. Run the following command to create a new Windows Service:
  ```
    sc.exe create WebsiteStatus binPath= "`{locationOfYourRelease}`\WebsiteStatus.exe" start= auto
  ``` 
3. Make sure you set appropriate auto status.
4. Execute the command.

## Process and command to stop and uninstall/remove the service

1. Stop the service you want to delete.
2. Open PowerShell as Administrator.
3. Run the following command to delete your created Windows Service:
  ```
    sc.exe delete <name of your Service>
  ``` 

  Note: if the service is not removed close Services console and reopen it.

