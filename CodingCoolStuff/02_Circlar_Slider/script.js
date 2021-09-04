
var line = document.getElementById("knob")
var angle = 0
var center = 250
var isMouseDown = false
var currentAngle = 0
line.setAttribute("transform", "rotate(" + angle + ",250,250)")

function mousemove() {
    var x = event.clientX
    var y = event.clientY
    if (isMouseDown) {
        line.setAttribute("transform", "rotate(" + x + ",250,250)")
    }
    // var v = y - center
    // var u = x - center

    // console.log(v)
    // console.log(u)

    // angle = Math.atan(v / u)

    // var degrees = (angle / (2 * Math.PI)) * 360
    // line.setAttribute("transform", "rotate(" + degrees + ",250,250)")
    // console.log(degrees)
}
function mouseup() {
    isMouseDown = false
}
function mousedown() {
    isMouseDown = true
}