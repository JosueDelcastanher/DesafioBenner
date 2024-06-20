using ProjectBenner;


var rede = new Rede(8);

rede.Connect(1, 2);
rede.Connect(6, 2);
rede.Connect(2, 4);
rede.Connect(5, 8);

var teste1 = rede.Query(1, 6); //conectados
var teste2 = rede.Query(6, 4); //conectados
var teste3 = rede.Query(7, 4); //não conectados
var teste4 = rede.Query(5, 8); //não conectados

var teste5 = rede.Query(1, 4); //conectados
var teste6 = rede.Query(1, 8); //não conectados

Console.WriteLine("Fim da execução");

