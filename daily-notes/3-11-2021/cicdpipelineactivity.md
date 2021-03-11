- we'll be building a pipeline for the toh app
- we'll come across multiple errors - I'm gonna take notes on them lol
- ci/cd pipelines


- use boards for p2



steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    projects: '**/*.sln'

- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/StoreTests/*.csproj'

- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    publishWebProjects: true
    workingDirectory: 'Weston_Davidson-P1'


NEED TO MAKE PIPELINE PRIVATE WTF?????
---------------------

    steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    projects: '**/*.sln'

- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/StoreTests/*.csproj'

- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    publishWebProjects: false
    zipAfterPublish: true
    projects: '**/StoreMVC/*.csproj'


- task: AzureRmWebAppDeployment@4
  inputs:
    ConnectionType: 'AzureRM'
    azureSubscription: 'Azure subscription 1(0bcf3285-b43d-4285-97f2-47f2ef104e66)'
    appType: 'webApp'
    WebAppName: 'sineshop'
    packageForLinux: '$(System.DefaultWorkingDirectory)/**/*.zip'