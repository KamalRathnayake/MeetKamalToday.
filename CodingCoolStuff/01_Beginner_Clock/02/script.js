function setPosition(handName, x, y) {
    var line = document.getElementById(handName)
    line.setAttribute("x1", x)
    line.setAttribute("y1", y)
}

var angle = -90
var minuteAngle = -90
var hourAngle = -90
var radius = 190
var center = 250

setInterval(() => {
    angle += 360 / 60
    var y = radius * Math.sin(angle / 360 * 2 * Math.PI) + center
    var x = radius * Math.cos(angle / 360 * 2 * Math.PI) + center
    setPosition("secondHand", x, y)

    minuteAngle += (360 / 60) / 60
    var my = radius * 0.8 * Math.sin(minuteAngle / 360 * 2 * Math.PI) + center
    var mx = radius * 0.8 * Math.cos(minuteAngle / 360 * 2 * Math.PI) + center
    setPosition("minuteHand", mx, my)

    hourAngle += ((360 / 60) / 60)/12
    var hy = radius * 0.6 * Math.sin(hourAngle / 360 * 2 * Math.PI) + center
    var hx = radius * 0.6 * Math.cos(hourAngle / 360 * 2 * Math.PI) + center
    setPosition("hourHand", hx, hy)

}, 10)