function setPosition(handName, x, y) {
    var line = document.getElementById(handName)
    line.setAttribute("x1", x)
    line.setAttribute("y1", y)
}