resource "kubernetes_service" "slot-ingress" {
  metadata {
    name = "slot-backend"
  }
  spec {
    selector = {
      App = kubernetes_deployment.slot-backend.spec.0.template.0.metadata[0].labels.App
    }
    port {
      port        = 80
      target_port = 80
    }

    type = "LoadBalancer"
  }
}

output "load_balancer_hostname" {
  value = kubernetes_service.slot-ingress.status.0.load_balancer.0.ingress.0.hostname
}
