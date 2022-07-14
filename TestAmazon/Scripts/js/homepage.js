function onMouseOver(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "background-color:rgb(240, 84, 84); ");
}
function onMouseLeft(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "background-color:white;");
}
function onMouseOverImage(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "transform:scale(1.10)");
}
function onMouseLeaveImage(id) {
    let div = document.getElementById(id);
    div.setAttribute("style", "transform:scale(1)");
}