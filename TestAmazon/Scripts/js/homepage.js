function onMouseOver(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "transform:scale(1.05) ; ");
}
function onMouseLeft(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "transform:scale(1);");
}
function onMouseOverImage(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "transform:scale(1.25) translate(0, 15%)");
}
function onMouseLeaveImage(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "transform:scale(1) translate(0, 15%)");
}