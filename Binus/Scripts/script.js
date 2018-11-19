var idx = 1;
var hapusChoice = 0;

function appendChoice(parentchoice) {
    var handler = $('#parentchoice' + parentchoice);
    handler.append
        (
        '<div class="subchoice' + hapusChoice + '">' +
            '<li>' +
                '<p>' +
                    '<input type="text" name="rows[' + idx + '][choice]" value=" "  style="display:inline-block; width:97%;"/>' +
                    '<a onclick="deletes(' + hapusChoice + ')"> <i class="icon icon-trash"></i></a>' +
                '</p>' +
            '</li>' +
        '</div>'
        );
    idx++;
    hapusChoice++;
}

function deletes(id) {
    var deletex = $('.subchoice' + id);
    deletex.html('');
}




var nomorSoal = 2;
var parentchoice = 1;

function deletescase(id) {
    var deletex = $('#createCase' + id);
    deletex.html('');
    nomorSoal--;
}

function appendCase() {
    var handler = $('.hapusQuestion');
    handler.append(
        '<div id="createCase' + parentchoice + '" class=""assessment"">' +
            '<p>' +
                '<a onclick="deletescase(' + parentchoice + ')"> <i class="icon icon-trash"></i></a>' +
                    '<label>' + nomorSoal + '<span class="required">*</span></label>' +
                        '<input type="text" name="rows[case][' + parentchoice + ']"/>' +
                            '</p>' +
                                '<ol type="a" id="parentchoice' + parentchoice + '">' +
                                    '<li>' +
                                        '<p>' +
                                            '<input type="text" name="rows[' + parentchoice + '][choice]" value=" "  style="display:inline-block; width:97%;"/>' +
                                        '</p>' +
                                    '</li>' +
                                '</ol>' +
                            '<p>' +
                '<a onclick="appendChoice(' + parentchoice + ');" class="button button-primary with-icon icon-btn-add" >Choice </a>' +
            '</p>' +
        '</div>'
        );
    nomorSoal++;
    parentchoice++;

}


$(document).ready(function () {

    $('#createCase').show();
    $('#createCaseProcrastonator').hide();
    $('#createCaseSensory').hide();

});

function appendCaseProcrastinator()
{
    var handler = $('.hapusQuestion');
    handler.append('<div id="createCaseProcrastonator' + parentchoice + '">' +
        '<p>' +
        '<a onclick="deletescaseProcrastinator(' + parentchoice + ')"> <i class="icon icon-trash"></i></a>' +
        '<label>' + nomorSoal + '<span class="required">*</span></label>' +
        '<input type="text" name="rows[case][' + parentchoice + ']"/>' +
        '</p>' +
        '</div>'
        );
    nomorSoal++;
    parentchoice++;
}

function deletescaseProcrastinator(id) {
    var deletex = $('#createCaseProcrastonator' + id);
    deletex.html('');
    nomorSoal--;
}

var index = 1;
function addScoreProcrastinator()
{
    var handler = $('.addScoreProcrastinator');
    handler.append(
        
        '<div class="column one-half proc' + index + '">' +
         
        '<p>' +
     
        '<label>'+
        'Score'+
        '</label>'+
        '<input type="text" name="rowsp[' + index + '][score]" />' +
        '</p>'+
        '</div>'+
        '<div class="column one-half">'+
        '<p>'+
        '<label>Word</label>'+
        '<input type="text" name="rowsp['+index+'][word]" />'+
        '</p>'+
        '</div>'
        
    );
    index++;
}


function test()
{
    var casetype = $('select[name=casetype]').val();
  
    if (casetype == 1)
    {
        $('#createCase').show();
        $('#createCaseProcrastonator').hide();
        $('#createCaseSensory').hide();
    }
    else if (casetype == 2)
    {
        $('#createCase').hide();
        $('#createCaseProcrastonator').show();
        $('#createCaseSensory').hide();
    }
    else if (casetype == 3) {
        $('#createCase').hide();
        $('#createCaseProcrastonator').hide();
        $('#createCaseSensory').show();
    }
}