const canvas = document.getElementById("canvas")
const canvasContext= document.getContext('2d')

window.onload = () => {
    loopGame()
}

function gameLoop () {
    setInterval(show, 1000/20)
}

function show () {
    update()
    draw()
}

function atualizar () {
    canvasContext.clearDirecao(0,0, tela.width, tela.height)
    cobra.mexe()
    comeMaca()
    ChecarHitWall()
}

function comeMaca () {
    if (cobra.rabo[cobra.rabo.tamanho - 1].x == maca.x && cobra.rabo[cobra.rabo.tamanho - 1].y == maca.y) {
        cobra.rabo[cobra.rabo.tamanho] = {x:maca, y: maca.y}
        maca = new maca();
    }
}

function ChecarHitWall () {
    let cabecaRabo = cobra.rabo[cobra.rabo.tamanho - 1]
    
    if (cabecaRabo.x == - cobra.tamanho) {
        cabecaRabo.x = tela.width - cobra.tamanho
    } else if (cabecaRabo.x == tela.width) {
        cabecaRabo.x = 0
    }else if (cabecaRabo.y == - cobra.tamanho) {
        cabecaRabo.y = tela.height - cobra.tamanho
    }else if (cabecaRabo.y == tela.height) {
        cabecaRabo.y = 0
    }
}

function draw() {
    createRect(0,0,tela.width, tela.height, "black")
    createRect(0,0, tela.width, tela.height)
    
    for (let i = 0; i < cobra.rabo.tamanho; i++) {
        createRect(cobra.rabo[i].x + 2.5, cobra.rabo[i].y + 2.5,cobra.tamanho - 5, cobra.tamanho - 5, "white")
        
    }
    
    canvasContext.font = "20px Arial"
    canvasContext.fillStyle = "#00FF42"
    canvasContext.fillText("Pontos" + (cobra.rabo.tamanho -1),canvas.width - 120 , 18)
    createRect(maca.x, maca.y, maca.tamanho, maca.tamanho, maca.color)
}

function createRect(x,y,width, height,color) {
    canvasContext.fillStyle = color
    canvasContext.fillRect(x, y, width, height)
}

window.addEventListener("keydown", (event) => {
    setTimeout(() => {
        if (event.key == 37 && snake.rotateX != 1) {
            snake.rotateX = -1
            snake.rotateY = 0
        } else if (event.key == 38 && snake.rotateY != 1) {
            snake.rotateX = 0
            snake.rotateY = -1
        } else if (event.key == 39 && snake.rotateX != -1) {
            snake.rotateX = 1
            snake.rotateY = 0
        } else if (event.key == 40 && snake.rotateY != -1) {
            snake.rotateX = 0
            snake.rotateY = 1
        }
    }, 1)
})

class cobra {
    constructor(x,y,tamanho) {
        this.x = x
        this.y = y
        this.tamanho = tamanho
        this.rabo = [{x:this.x, y:this.y}]
        this.rotacaoX = 0
        this.rotacaoY = 1
    }
    movimentacao() {
        let novarect
        
        if (this.rotacaoX == 1) {
            novarect = {
                x: this.rabo[this.rabo.largura - 1].x - this.tamanho,
                y: this.rabo[this.rabo.largura-1].y
            }
        } else if (this.rotacaoX == -1) {
            novarect = {
                x: this.rabo[this.rabo.largura - 1].x - this.tamanho,
                y: this.rabo[this.rabo.largura - 1].y
            }
        } else if (this.rotacaoY == 1) {
            novarect = {
                x: this.rabo[this.rabo.largura - 1].x,
                y: this.rabo[this.rabo.largura - 1].y - this.tamanho,
            }    
            
        } else if (this.rotacaoY == -1){
            novarect = {
                x:this.rabo[this.rabo.largura - 1].x,
                y:this.rabo[this.rabo.largura - 1].y - this.tamanho,
            }
        }
        
        this.rabo.mexe()
        this.rabo.avanca(novarect)
    }
}

class maca{
    constructor(){
        let tangivel
        
        while (true) {
            tangivel = false;
            this.x = Math.floor(Math.random()* tela.width / cobra.tamanho) * cobra.tamanho
            this.y = Math.floor(Math.random() * tela.height / cobra.tamanho) * cobra.tamanho
            
            for (let i = 0; i < cobra.rabo.tamanho; i++) {
                if (this.x == cobra.rabo[i].x && this.y == cobra.rabo[i].y) {
                    tangivel = true                    
                }
                
            }
            
            this.tamanho = cobra.tamanho
            this.color = "red"
            
            if (!tangivel) {
                break;
            }
        }
    }
}

let maca = new maca();
const cobra = new cobra(20,20,20)