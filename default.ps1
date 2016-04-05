properties {
  $rabbitmqctl = 'C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.5.4\sbin\rabbitmqctl.bat'
}

task default -depends test

task compile {
  exec {msbuild /v:quiet Cronny.sln}
}

task test -depends check-env, compile {
  exec {& .\packages\Fixie.1.0.0.41\lib\net45\Fixie.Console.exe .\Cronny.Tests\bin\Debug\Cronny.Tests.dll}
}

task check-env {
  if(!(test-path $rabbitmqctl)) {
    throw "Looks like RabbitMQ is not installed: rabbitmqctl not found at $rabbitmqctl"
  }
  if ((& $rabbitmqctl status) -match 'error') {
    throw 'Looks like RabbitMQ is stopped'
  }
}

task init-env {
  if(test-path $rabbitmqctl) {
    throw "Looks like RabbitMQ already installed: rabbitmqctl found at $rabbitmqctl"
  }
  cinst -y rabbitmq
}
