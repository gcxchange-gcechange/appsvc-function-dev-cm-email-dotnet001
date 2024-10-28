# appsvc-function-dev-cm-email-dotnet001

## Summary

Provides email functionality for career marketplace workflows
  
## Prerequisites

The following user accounts (as reflected in the app settings) are required:

| Account             | Membership requirements                                  |
| ------------------- | -------------------------------------------------------- |
| delegateEmail       | |

## Version 

![dotnet 8](https://img.shields.io/badge/net8.0-blue.svg)

## API permission

MSGraph

| API / Permissions name    | Type        | Admin consent | Justification             |
| ------------------------- | ----------- | ------------- | ------------------------- |
| Mail.Send                 | Delegated   | Yes           | Send email                | 
| User.Read                 | Delegated   | Yes           | Read user for mail sender | 

## App setting

| Name                        | Description                                         |
| --------------------------- | --------------------------------------------------- |
| AzureWebJobsStorage         | Connection string for the storage acoount           |
| tenantId                    | Id of the Azure tenant that hosts the function app  |
| clientId                    | The application (client) ID of the app registration |
| keyVaultUrl                 | Address for the key vault                           |
| secretNameClient            | Secret name used to authorize the function app      |
| delegateEmail				  | The email sender address                            |
| secretNameDelegatePassword  | The secret name for the email sender password       |

## Version history

Version|Date|Comments
-------|----|--------
1.0|2024-10-28|Initial release

## Disclaimer

**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**