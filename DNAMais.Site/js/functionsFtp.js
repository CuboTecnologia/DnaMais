function ftpTransitionEffect() {

    $('#divPf, #divPj, #divVehicle').hide();
    $('#btnDefaultFtp').hide();
    $('#btnFtpPhaseTwo').show();
    $('div.grid-ftp').addClass('grid-ftp-after');
    $('#divFtp').removeClass('effect-sadie');
    $('#divFtp').addClass('effect-sadie-2');

    setTimeout(function () {

        $('#btnBackFtp').fadeIn(800);

    }, 1000);

}