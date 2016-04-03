task default -depends test

task compile {
  exec {msbuild /v:quiet Cronny.sln}
}

task test -depends compile {
  exec {& .\packages\Fixie.1.0.0.41\lib\net45\Fixie.Console.exe .\Cronny.Tests\bin\Debug\Cronny.Tests.dll}
}
