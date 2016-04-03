task default -depends compile

task compile {
  exec {msbuild /v:quiet Cronny.sln}
}
