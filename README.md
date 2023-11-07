# EKS Sample: A Unity-Based Slot Machine Game

Welcome to my project, "EKS Sample". This project is a simple slot machine game built with Unity. The game communicates with a straightforward API backend to perform the spin operation. 

I developed this project as a personal learning endeavor to understand the integration of various technologies such as [Terraform](https://www.terraform.io/), [Kubernetes](https://kubernetes.io/), [AWS](https://aws.amazon.com/), and [Unity](https://unity.com/). 

## Architecture

The game client is developed using Unity, a powerful cross-platform game development engine. The client communicates with an API backend for game operations. The APIs are designed and generated using [OpenAPI](https://www.openapis.org/) (formerly known as Swagger), a specification for machine-readable interface files for describing, producing, consuming, and visualizing RESTful web services. OpenAPI's versatility allows for the generation of clients/servers for languages beyond C#, offering a wide range of possibilities for future enhancements.

## Infrastructure

The backend of the application is hosted on an EKS (Elastic Kubernetes Service) cluster, created and managed using Terraform. Terraform is an open-source infrastructure as code software tool that provides a consistent CLI workflow to manage hundreds of cloud services. It is used in this project not only to create the EKS cluster but also to deploy the API to the cluster. 

## Credits

The slot machine icons used in this project are sourced from [Icons8](https://icons8.com). Here are the mandatory links to the icons used:

- [Grapefruit](https://icons8.com/icon/LJw0Z94vqp2G/grapefruit) icon by Icons8
- [Lemon](https://icons8.com/icon/jtFK0QKYEG3e/lemon) icon by Icons8
- [Lime](https://icons8.com/icon/sRGGhn3hfWzK/lime) icon by Icons8
- [Orange](https://icons8.com/icon/wlASvJsDH2qh/orange) icon by Icons8


I hope you find this project interesting. Enjoy exploring and happy coding!
