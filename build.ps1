.\packages\psake.4.6.0\tools\psake.ps1 .\default.ps1 $args
exit !$psake.build_success
