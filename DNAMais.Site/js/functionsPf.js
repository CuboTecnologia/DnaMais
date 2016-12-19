function pfTransitionEffect() {

    $('#divPj').hide();
    $('#divVehicle').hide();
    $('#divFtp').hide();
    $('#btnDefault').hide();
    $('#btnPhaseTwo').show();
    $('div.grid-pf').addClass('grid-pf-after');
    $('#divPf').removeClass('effect-sadie');
    $('#divPf').addClass('effect-sadie-2');

    setTimeout(function () {

        $('#btnBack').fadeIn(800);

    }, 1000);

}

function cpfClickPhaseTwo() {

    setTimeout(function () {

        $('#pfCpf').fadeIn(500);
        $('#pfAddr,#pfName,#pfTel').hide();
        $('#txtCpf').focus();

    }, 1);

}

function addressClickPhaseTwo() {

    setTimeout(function () {

        $('#pfAddr').fadeIn(500);
        $('#pfCpf,#pfName,#pfTel').hide();
        $('#txtAddr').focus();

    }, 1);

}

function nameClickPhaseTwo() {

    setTimeout(function () {

        $('#pfName').fadeIn(500);
        $('#pfCpf,#pfAddr,#pfTel').hide();
        $('#txtName').focus();

    }, 1);

}

function telClickPhaseTwo() {

    setTimeout(function () {

        $('#pfTel').fadeIn(500);
        $('#pfCpf,#pfName,#pfAddr').hide();
        $('#txtTel').focus();

    }, 1);

}