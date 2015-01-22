var uri = 'api/inmate';

$(document).ready(function () {
    $.getJSON(uri).done(function (stuff)                                             // Send an AJAX request
    {
        $.each(stuff, function (key, inmate)                                         // On success, 'stuff' contains a list of inmates.
        {
            $('<li>', { text: formatInmate(inmate) }).appendTo($('#inmates'));      // Add a list item for the inmate.
        });
    });
});

function formatInmate(inmate) {
    return inmate.ID + ':  ' + inmate.name + ', DOB:  ' + inmate.DOB;
}

function find() {
    var inmateID = $('#inmateID').val();
    $.getJSON(uri + '/' + inmateID)
        .done(function (stuff) { $('#inmate').text(formatInmate(stuff)); })
        .fail(function (jqXHR, textStatus, err) { $('#inmate').text('Error: ' + err); });
}