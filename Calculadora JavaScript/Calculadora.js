function inserir(numero){
   var num = document.getElementById('Resultado').innerHTML;//inserir os numeros no input Resultado
   document.getElementById('Resultado').innerHTML = num + numero; //adiciona um numero ao lado do outro
}

function limpar(){
document.getElementById('Resultado').innerHTML = ""//substitui numeros por nada quando metodo clear é implementado
}

function Apagar(){
    var Resultado = document.getElementById('Resultado').innerHTML;
    document.getElementById('Resultado').innerHTML = Resultado.substring(0,Resultado.length -1)
}

function Calcular(){
    var resultado = document.getElementById('Resultado').innerHTML;
    if (resultado) 
    {
        document.getElementById('Resultado').innerHTML =  eval(resultado);
    } else 
    {
       document.getElementById('Resultado').innerHTML= "Nada..."
    } 
}