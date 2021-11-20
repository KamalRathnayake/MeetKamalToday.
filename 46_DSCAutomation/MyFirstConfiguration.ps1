Configuration MyFirstConfiguration {
  
    Import-DscResource -ModuleName PsDesiredStateConfiguration
  
    Node "localhost" {
      
      # hello world from file
      File HelloWorld {
          DestinationPath = "C:\Temp\HelloWorld.txt"
          Ensure = "Present"
          Contents   = "Getting started with DSC!"
      }
  
      # install IIS
      WindowsFeature MyFeatureInstance {
        Ensure = 'Present'
        Name = 'Web-Server'
      }
  
    }
  }