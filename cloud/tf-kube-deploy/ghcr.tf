variable "ghcrtoken" {
  description = "PAT for the Github Package registry"
  type = string
  default = "us-east-1"
}

resource "kubernetes_secret" "ghcr-registry" {
  metadata {
    name = "ghcrsecret"
  }

  data = {
    ".dockerconfigjson" = "${data.template_file.docker_config_script.rendered}"
  }

  type = "kubernetes.io/dockerconfigjson"
}


data "template_file" "docker_config_script" {
  template = "${file("${path.module}/ghcr-secret.json")}"
  vars = {
    pat = "${var.ghcrtoken}"
  }
}
