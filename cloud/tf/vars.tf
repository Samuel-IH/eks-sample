# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

// Pretty easy to understand. These are vars that can be customized via command line and, I'm assuming, environment.
variable "region" {
  description = "AWS region"
  type = string
  default = "us-east-1" // Because I'm in AL
}