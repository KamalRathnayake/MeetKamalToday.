var boxWidth = 100
var width = 10
var height = 10

var world = Array.from(Array(width), () => new Array(height))

function drawWorld() {
    var canvas = document.getElementById("canvas")
    while (canvas.firstChild) {
        canvas.removeChild(canvas.firstChild);
    }
    for (var i = 0; i < width; i++) {
        for (var j = 0; j < height; j++) {
            var rect = document.createElementNS("http://www.w3.org/2000/svg", "rect")
            rect.setAttribute("x", boxWidth * i);
            rect.setAttribute("y", boxWidth * j);
            rect.setAttribute("width", boxWidth);
            rect.setAttribute("height", boxWidth);
            if (world[i][j] == 1) {
                rect.setAttribute("style", "fill:red;");
            } else {
                rect.setAttribute("style", "fill:white;");
            }
            canvas.appendChild(rect)
        }
    }
}


var egg = [4,4]
setInterval(()=>{
    world[egg[0]][egg[1]]=1
    egg[1]++
    drawWorld()
}, 3000)