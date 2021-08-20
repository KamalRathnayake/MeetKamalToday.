function setPosition(handName, x, y) {
    var line = document.getElementById(handName)
    line.setAttribute("x1", x)
    line.setAttribute("y1", y)
}

var radius = 200
var center = 250
var secondAngle = -180
var minuteAngle = -180
var hourAngle = -180

setInterval(() => {
    secondAngle -= 360 / 60
    var secondX = radius * Math.sin(secondAngle / 360 * 2 * Math.PI)
    var secondY = radius * Math.cos(secondAngle / 360 * 2 * Math.PI)
    setPosition("secondHand", secondX + center, secondY + center)

    minuteAngle -= (360 / 60) / 60
    var minuteX = radius / 1.5 * Math.sin(minuteAngle / 360 * 2 * Math.PI)
    var minuteY = radius / 1.5 * Math.cos(minuteAngle / 360 * 2 * Math.PI)
    setPosition("minuteHand", minuteX + center, minuteY + center)

    hourAngle -= ((360 / 60) / 60) / 12
    var hourX = radius / 1.75 * Math.sin(hourAngle / 360 * 2 * Math.PI)
    var hourY = radius / 1.75 * Math.cos(hourAngle / 360 * 2 * Math.PI)
    setPosition("hourHand", hourX + center, hourY + center)
}, 10)