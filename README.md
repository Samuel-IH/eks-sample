# EKS Sample: A Unity-Based Slot Machine Game

Welcome to my project, "EKS Sample". This project is a simple slot machine game built with Unity. The game communicates with a straightforward API backend to perform the spin operation. 

I developed this project as a personal learning endeavor to understand the integration of various technologies such as [Terraform](https://www.terraform.io/), [Kubernetes](https://kubernetes.io/), [AWS](https://aws.amazon.com/), and [Unity](https://unity.com/). 

## Architecture

The game client is developed using Unity, a powerful cross-platform game development engine. The client communicates with an API backend for game operations. The APIs are designed and generated using [OpenAPI](https://www.openapis.org/) (formerly known as Swagger), a specification for machine-readable interface files for describing, producing, consuming, and visualizing RESTful web services. OpenAPI's versatility allows for the generation of clients/servers for languages beyond C#, offering a wide range of possibilities for future enhancements.

## Infrastructure

The backend of the application is hosted on an EKS (Elastic Kubernetes Service) cluster, created and managed using Terraform. Terraform is an open-source infrastructure as code software tool that provides a consistent CLI workflow to manage hundreds of cloud services. It is used in this project not only to create the EKS cluster but also to deploy the API to the cluster.

## Deployment

### Backend
The backend is already built on this repository and stored as a Docker image on GHCR (GitHub Container Registry). However, to pull packages from GHCR the kubernetes service will need a PAT (Personal Access Token) with the `read:packages` scope. You can create a PAT by following the instructions [here](https://docs.github.com/en/github/authenticating-to-github/keeping-your-account-and-data-secure/creating-a-personal-access-token).

### Cloud
To deploy to the cloud you will need an AWS account, and you will need to authenticate your aws cli. You can find instructions on how to do that [here](https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-quickstart.html). The CLI itself is pre-installed in the devcontainer under the `cloud` directory, so feel free to open up a VSCode instance in the `cloud` directory and run the commands from there.

Once you authenticate with aws, you should be able to simply run:
    
```bash
terraform apply -var ghcrtoken="<your-pat>" -var ghcruser="<your-gh-username>"
```
in the `tf` directory.

This will create the EKS cluster, deploy the backend to it, and should also spit out the load balancer endpoint url. You can then use this url to run the frontend.

### Cleanup
To clean up the resources created by terraform, simply run:
```bash
terraform destroy
```
in the `tf` directory.

This will delete the EKS cluster and all the resources created by terraform.

### Frontend
To run the frontend, simply import the SlotMachine directory into Unity Hub as a project. Unity Hub should automatically detect the project and add it to the list of projects. Select the project and click the "Open" button to open the project in Unity Editor. Once the project is open, click the "Play" button to run the game. You will be presented with a text input at the top, and a button on the bottom. Paste in the endpoint url of your loadbalancer at the top and click the button to "spin" the wheel. The game will then communicate with the backend to perform the spin operation. The result of the spin will be displayed in the middle of the screen.

## Credits

The slot machine icons used in this project are sourced from [Icons8](https://icons8.com). Here are the mandatory links to the icons used:

- [Grapefruit](https://icons8.com/icon/LJw0Z94vqp2G/grapefruit) icon by Icons8
- [Lemon](https://icons8.com/icon/jtFK0QKYEG3e/lemon) icon by Icons8
- [Lime](https://icons8.com/icon/sRGGhn3hfWzK/lime) icon by Icons8
- [Orange](https://icons8.com/icon/wlASvJsDH2qh/orange) icon by Icons8


I hope you find this project interesting. Enjoy exploring and happy coding!
