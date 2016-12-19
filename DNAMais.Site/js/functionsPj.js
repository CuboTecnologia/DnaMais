function pjTransitionEffect() {

    $('#divPf, #divVehicle, #divFtp').hide();
    $('#btnDefaultPj').hide();
    $('#btnPjPhaseTwo').show();
    $('div.grid-pj').addClass('grid-pj-after');
    $('#divPj').removeClass('effect-sadie');
    $('#divPj').addClass('effect-sadie-2');

    setTimeout(function () {

        $('#btnBackPj').fadeIn(800);

    }, 1000);

}

function cnpjClickPhaseTwo() {

    setTimeout(function () {

        $('#pjCnpj').fadeIn(500);
        $('#pjRs,#pjTel').hide();
        $('#txtCnpj').focus();

    }, 1);

}

function rsClickPhaseTwo() {

    setTimeout(function () {

        $('#pjRs').fadeIn(500);
        $('#pjCnpj,#pjTel').hide();
        $('#txtRs').focus();

    }, 1);

}

function telPjClickPhaseTwo() {

    setTimeout(function () {

        $('#pjTel').fadeIn(500);
        $('#pjCnpj,#pjRs').hide();
        $('#txtTelPj').focus();

    }, 1);

}