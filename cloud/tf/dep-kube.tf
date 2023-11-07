
data "aws_eks_cluster" "slot_cluster" {
  name = module.eks.cluster_name
}

provider "kubernetes" {
  host                   = module.eks.cluster_endpoint
  cluster_ca_certificate = base64decode(data.aws_eks_cluster.slot_cluster.certificate_authority[0].data)
  exec {
    api_version = "client.authentication.k8s.io/v1beta1"
    command     = "aws"
    args = [
      "eks",
      "get-token",
      "--cluster-name",
      module.eks.cluster_name
    ]
  }
}


resource "kubernetes_deployment" "slot-backend" {
  metadata {
    name = "slot-backend"
    labels = {
      App = "SlotBackend"
    }
  }

  spec {
    replicas = 2
    selector {
      match_labels = {
        App = "SlotBackend"
      }
    }
    template {
      metadata {
        labels = {
          App = "SlotBackend"
        }
      }
      spec {

        image_pull_secrets {
            name = "ghcrsecret"
        }

        container {
          image = "ghcr.io/samuel-ih/eks-sample:main@sha256:598193d26d4b3758a4ae60d59d6ec61e0f0a8c91f70d70882e5c8ddf03ad5956"
          name  = "slot-backend"

          port {
            container_port = 80
          }

          resources {
            limits = {
              cpu    = "0.5"
              memory = "512Mi"
            }
            requests = {
              cpu    = "250m"
              memory = "50Mi"
            }
          }
        }
      }
    }
  }
}
