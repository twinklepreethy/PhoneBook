var Index = {};

Index.Selectors = {
    ContactsTableSelector: '[data-selector="ContactsTable"]',
    SearchInputSelector: '[data-selector="SearchInput"]',
    NoContactsError: '[data-selector="NoContactsError"]',
    DeleteContact: '[data-selector="DeleteContact"]',
    AddContact: '[data-selector="AddContact"]',
    IndexPage: '[data-selector="IndexPage"]',
    EditSelector: '[data-selector="EditContact"]'
};

Index.ContactsData = [];

$(function () {

    $(Index.Selectors.SearchInputSelector).on("keyup", function () {
        debugger;
        var val = $.trim(this.value);
        var filteredList = Index.ContactsData;
        if (val) {
            val = val.toUpperCase();

            $('tr').hide();

            $('td').filter(function () {
                var lastName = $(this).data('name');
                if (lastName) return lastName.toUpperCase().indexOf(val) > -1
            }).parent().show();
            //filteredList = $.grep(Index.ContactsData, function (obj, index) {
            //    var substring = obj.lastName.toUpperCase().substring(0, val.length);

            //    return substring;
            //});
        }
        else {
            $('tr').show();
        }

        $(Index.Selectors.NoContactsError).toggle($(Index.Selectors.ContactsTableSelector).find("tr").length == 0);
    });

    $.get("https://localhost:7268/api/Contacts", function (data, status) {
        if (status == 'success') {
            debugger;
            Index.ContactsData = data;
            Index.CreateTable(data);
        }
    });

    $(Index.Selectors.ContactsTableSelector).on("click", Index.Selectors.DeleteContact, function () {
        var currentId = $(this).data('id');
        $.ajax({
            type: "DELETE",
            url: "https://localhost:7268/api/Contacts/" + currentId,
            data: {
                id: JSON.stringify(currentId)
            },
            cache: false,
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                debugger;

                var column = $("td").find('[data-id=' + currentId + ']');
                $(column[0]).parent().parent().remove();
            }
        });
    });

    $(Index.Selectors.IndexPage).on("click", Index.Selectors.EditSelector, function () {
        debugger;
        var id = $(this).data('id');
        $.ajax({
            type: 'POST',
            url: '/Home/UpdateContact/' + id,
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            data: JSON.stringify({ currentContactID: id }),
            success: function (data) {
                debugger;

            }
        });
    });

    $(Index.Selectors.IndexPage).on("click", Index.Selectors.AddContact, function () {
        $.get("/Home/AddContact", function (data) {
            $(Index.Selectors.IndexPage).html('');
            $('#AddContact').html(data);
        });        
    });
});

Index.CreateTable = function (data) {
    var html = '';
    for (var i = 0; i < data.length; i++) {
        html += '<tr>'
        html += '<td class="col-sm-2" style="text-align:center" data-name="' + data[i].lastName + '">' + Index.GetFullName(data[i].firstName, data[i].lastName) + '</td>';
        html += '<td class="col-sm-2" style="text-align:center">' + data[i].phoneNumber + '</td>';
        html += '<td class="col-sm-2" style="text-align:center"><button data-selector="EditContact" class="btn btn-default" style="text-decoration:underline" data-id="' + data[i].id + '">Edit</button></td>';
        html += '<td class="col-sm-2" style="text-align:center"><button data-selector="DeleteContact" class="btn btn-default" style="text-decoration:underline" data-id="' + data[i].id + '">Delete</button></td>';
        html += '/<tr>'
    }
    $(Index.Selectors.ContactsTableSelector).append(html);
    //$.ajax({
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    url: "Default.aspx/Data",
    //    data: "{}",
    //    dataType: "json",
    //    success: function (data) {
    //        alert(data.d);
    //        var list = { "Person": +data };
    //        for (i = 0; i < list.Person.length; i++) {
    //            alert('Id: ' + list.Person[i].Id + '/nName: ' + list.Person[i].Name + '/nPhone: ' + list.Person[i].Phone);
    //            console.log('Id: ' + list.Person[i].Id + '/nName: ' + list.Person[i].Name + '/nPhone: ' + list.Person[i].Phone);
    //        }
    //        console.log(list.Person.length);
    //    },
    //    error: function (result) {
    //        alert("Error");
    //    }
    //});
};

Index.UpdateTable = function (data) {
    $(Index.Selectors.ContactsTableSelector).html("");

    Index.CreateTable(data);
};

Index.GetFullName = function (firstName, lastName) {
    return firstName + ' ' + lastName;
};