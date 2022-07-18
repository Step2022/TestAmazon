﻿function onMouseOver(id) {
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
    switch (select.value) {
        case "0":

            break;
        case "1":

            if (ids != null) {
                $.ajax({
                    type: 'GET',
                    success: function (data) {
                        window.location.href = "../../Preferiti/Preferiti/" + ids;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }

            break;
        case "2":
            if (ids != null) {
                $.ajax({
                    type: 'GET',
                    success: function (data) {
                        window.location.href = "../../Carrello/CarrelloUtente";
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
            break;
    }
}
function plus(NumeroPagine) {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }


    if (label != null) {
        let stringa = "../../Home/Index?pag=";
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            stringa += (parseInt(label.innerHTML.trim()) + 1);

        } else {
            stringa += 1;
        }
        if (parseInt(label.innerHTML.trim()) < NumeroPagine) {
            $.ajax({
                type: 'GET',
                success: function (data) {
                    window.location.href = stringa;
                },
                error: function () {
                    alert('error happened');
                }
            });
        }
    }
}
function minus() {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            if (parseInt(label.innerHTML.trim()) > 1) {
                let stringa = "../../Home/Index?pag=";
                if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
                    stringa += (parseInt(label.innerHTML.trim()) - 1);

                } else {
                    stringa += 1;
                }
                $.ajax({
                    type: 'GET',
                    success: function (data) {
                        window.location.href = stringa;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
        } else {
            label.innerHTML = 0
        }
    }
}
function first() {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    let stringa = "../../Home/Index?pag=1";
    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            if (parseInt(label.innerHTML.trim()) != 1) {
                $.ajax({
                    type: 'GET',
                    success: function (data) {
                        window.location.href = stringa;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
        }

    }
}
function last(NumeroPagine) {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }


    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            if (label.innerHTML.trim() != NumeroPagine) {
                let stringa = "../../Home/Index?pag=" + NumeroPagine;
                $.ajax({
                    type: 'GET',
                    success: function (data) {
                        window.location.href = stringa;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
        }
    }
}
function plusCategory(NumeroPagine) {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    if (label != null) {
        let stringa = "../../Ricerca/Categorys?searchText=" + testRicerca + "&searchCategory=" + CategoriaRicerca + "&pag=";
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            stringa += (parseInt(label.innerHTML.trim()) + 1);

        } else {
            stringa += 1;
        }
        if (parseInt(label.innerHTML.trim()) < NumeroPagine) {
            $.ajax({
                type: 'GET',
                url: window.location.href = stringa,
                success: function (data) {
                    window.location.href = stringa;
                },
                error: function () {
                    alert('error happened');
                }
            });
        }
    }
}
function minusCategory() {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            if (parseInt(label.innerHTML.trim()) > 1) {
                let stringa = "../../Ricerca/Categorys?searchText=" + testRicerca + "&searchCategory=" + CategoriaRicerca + "&pag=";
                if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
                    stringa += (parseInt(label.innerHTML.trim()) - 1);

                } else {
                    stringa += 1;
                }
                $.ajax({
                    type: 'GET',
                    url: window.location.href = "/Ricerca/Categorys",
                    success: function (data) {
                        window.location.href = stringa;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
        } else {
            label.innerHTML = 0
        }
    }
}
function firstCategory() {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            if (parseInt(label.innerHTML.trim()) != 1) {
                let stringa = "../../Ricerca/Categorys?searchText=" + testRicerca + "&searchCategory=" + CategoriaRicerca + "&pag=1";

                $.ajax({
                    type: 'GET',
                    url: window.location.href = "/Ricerca/Categorys",
                    success: function (data) {
                        window.location.href = stringa;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
        }

    }
}
function lastCategory(NumeroPagine) {
    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {
            if (label.innerHTML.trim() != NumeroPagine) {
                let stringa = "../../Ricerca/Categorys?searchText=" + testRicerca + "&searchCategory=" + CategoriaRicerca + "&pag=" + NumeroPagine;

                $.ajax({
                    type: 'GET',
                    url: window.location.href = "/Ricerca/Categorys",
                    success: function (data) {
                        window.location.href = stringa;
                    },
                    error: function () {
                        alert('error happened');
                    }
                });
            }
        }
    }
}
function sendResearch() {

    let label = document.getElementById("numPag");
    let CategoriaRicerca = "";
    if (document.getElementById("searchCategory") != null) {
        CategoriaRicerca = document.getElementById("searchCategory").value;
    }
    let testRicerca = ""
    if (document.getElementById("searchText") != null) {
        testRicerca = document.getElementById("searchText").value;
    }

    if (label != null) {
        if ((new RegExp("^[0-9]+$")).test(label.innerHTML.trim())) {

            let stringa = "../../Ricerca/Categorys?searchText=" + testRicerca + "&searchCategory=" + CategoriaRicerca + "&pag=1";

            $.ajax({
                type: 'GET',
                url: window.location.href = stringa,
                success: function (data) {
                    window.location.href = stringa;
                },
                error: function () {
                    alert('error happened');
                }
            });

        }

    }
}
