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
function OnChangeDDLUser(ids) {
    let select = document.getElementById("select_user");
    alert(select.value)
    switch (select.value) {
        case 0:

            break;
        case "1":

            if ( ids != null) {
                $.ajax({
                    type: 'GET',
                    
                    
                    success: function (data) {
                        window.location.href = "../../Preferiti/Preferiti/"+ids;
                    },
                    error: function () {
                        alert('error happened');
                    }
                    });
                }

        break;
    }
}