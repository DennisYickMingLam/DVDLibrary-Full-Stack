$(document).ready(function () {
    showTable();
    addDVD();
    editDVD();
    
});
function showTable() {
    emptyForm();
    emptyErrorMessage();
    $('#dvdTableDiv').show();
    $('#generalFormDiv').hide();
    $('#detailFormDiv').hide();
    loadDVD('none');
}
function loadDVD(category, term) {
    clearDVDTable();
    var contentRows = $('#contentRows');
    var searchCategory = '';
    var searchTerm = '';
    if (category != 'none') {
        searchCategory = '/' + category;
        searchTerm = '/' + term;
    }

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44374/dvds' + searchCategory + searchTerm,
		//url: 'http://dvd-library.us-east-1.elasticbeanstalk.com/dvds' + searchCategory + searchTerm,
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var dvdId = dvd.dvdId;
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;

                var row = '<tr>';
                row += '<td><a onclick="showDetail(' + dvdId + ')">' + title + '</a></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-info" onclick="showForm(' + dvdId + ')">Edit</button><text> | </text><button type="button" class="btn btn-danger" onclick="deleteDVD(' + dvdId + ')">Delete</button></td>';
                row += '</tr>';
                contentRows.append(row);
            })
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })
}

function showForm(input) {
    emptyErrorMessage();
    emptyForm();
    $('#dvdTableDiv').hide();
    $('#generalFormDiv').show();
    $('#detailFormDiv').hide();
    if (input == 'create') {
        $('#addButton').show();
        $('#saveButton').hide();
        $('#generalFormHeader').text("Create Dvd");
    } else {
        $('#addButton').hide();
        $('#saveButton').show();
        showEditForm(input);
    }
}
function addDVD() {
    $('#generalFormCreateButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#generalFormDiv').find('input'));
        if (haveValidationErrors) { return false; }
        // Creating a new DVD
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44374/dvd',
			//url: 'http://dvd-library.us-east-1.elasticbeanstalk.com/dvd',
            data: JSON.stringify({
                title: $('#generalFormTitle').val(),
                releaseYear: $('#generalFormYear').val(),
                director: $('#generalFormDirector').val(),
                rating: $('#generalFormRating').val(),
                notes: $('#generalFormNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                showTable();
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    })
}
function showEditForm(dvdId) {
    // Retrieving a DVD by Id
	
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44374/dvd/' + dvdId,
		//url: 'http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/' + dvdId,
        success: function (data, status) {
			console.log("data.dvdId: " + data.dvdId);
            $('#generalFormId').val(dvdId);
            $('#generalFormHeader').text("Edit Dvd: " + data.title);
            $('#generalFormTitle').val(data.title);
            $('#generalFormYear').val(data.releaseYear);
            $('#generalFormDirector').val(data.director);
            $('#generalFormRating').val(data.rating);
            $('#generalFormNotes').val(data.notes);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })

}
function editDVD() {
    $('#generalFormChangeButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#generalFormDiv').find('input'));
        if (haveValidationErrors) { return false; }
        // Updating an Existing DVD
		$.ajax({
            type: 'PUT',
            url: 'https://localhost:44374/dvd/' + $('#generalFormId').val(),
			//url: 'http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/' + $('#generalFormId').val(),
            data: JSON.stringify({
				dvdId: $('#generalFormId').val(),
                title: $('#generalFormTitle').val(),
                releaseYear: $('#generalFormYear').val(),
                director: $('#generalFormDirector').val(),
                rating: $('#generalFormRating').val(),
                notes: $('#generalFormNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            //dataType: 'json',
            success: function () {
                showTable();
            },
            error: function (e) {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    })
}

function showDetail(dvdId) {
    emptyErrorMessage();
    $('#dvdTableDiv').hide();
    $('#generalFormDiv').hide();
    $('#detailFormDiv').show();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44374/dvd/' + dvdId,
		//url: 'http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/' + dvdId,
        success: function (data, status) {
            $('#detailTitle').text(data.title);
            $('#detailYear').text(data.releaseYear);
            $('#detailDirector').text(data.director);
            $('#detailRating').text(data.rating);
            $('#detailNotes').text(data.notes);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })
}

function searchDVD() {
    emptyErrorMessage();
    console.log($('#dropdown').val());
    console.log($('#searchTerm').val());
    var error = false;
    if ($('#dropdown').val() == null) {
        $('#errorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Search category is required'));
        error = true;
    }
    if ($('#searchTerm').val().length == 0) {
        $('#errorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Search term is required'));
        error = true;
    }
    if (!error) {

        loadDVD($('#dropdown').val(), $('#searchTerm').val());
        
    } 
}

function clearDVDTable() {
    $('#contentRows').empty();
}
function checkAndDisplayValidationErrors(input) {
    emptyErrorMessage();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });
    
    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}
function emptyForm() {
    $('#generalFormTitle').val('');
    $('#generalFormYear').val('');
    $('#generalFormDirector').val('');
    $('#generalFormRating').val('G');
    $('#generalFormNotes').val('');
}
function emptyErrorMessage() {
    $('#errorMessages').empty();
}
function deleteDVD(dvdId) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44374/dvd/' + dvdId,
		//url: 'http://dvd-library.us-east-1.elasticbeanstalk.com/dvd/' + dvdId,
        success: function () {
            showTable();
        }
    });
}
