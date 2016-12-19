function vehicleTransitionEffect() {

    $('#divPf, #divPj, #divFtp').hide();
    $('#btnDefaultVehicle').hide();
    $('#btnVehiclePhaseTwo').show();
    $('div.grid-vehicle').addClass('grid-vehicle-after');
    $('#divVehicle').removeClass('effect-sadie');
    $('#divVehicle').addClass('effect-sadie-2');

    setTimeout(function () {

        $('#btnBackVehicle').fadeIn(800);

    }, 1000);

}