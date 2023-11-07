variable "ghcrtoken" {
  description = "PAT for the Github Package registry"
  type = string
  default = "us-east-1"
}

variable "ghcruser" {
  description = "User for the Github Package registry"
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
  template = "${file("${path.module}/ghcr-auth-template.json")}"
  vars = {
    auth = base64encode("${var.ghcruser}:${var.ghcrtoken}")
  }
}
