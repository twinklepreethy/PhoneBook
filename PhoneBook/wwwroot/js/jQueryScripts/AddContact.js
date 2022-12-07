var AddContact = {};

AddContact.Selectors = {
    AddContactPage: '[data-selector="AddContactPage"]',
    CancelContact: '[data-selector="CancelContact"]',
    CreateContact: '[data-selector="CreateContact"]',
    FirstName: '[data-selector="FirstName"]',
    LastName: '[data-selector="LastName"]',
    PhoneNumber: '[data-selector="PhoneNumber"]'
};

$(function () {

    $(AddContact.Selectors.AddContactPage).on('click', AddContact.Selectors.CancelContact, function () {
        $.get("/Home/Index", function (data) {
            $('#AddContact').html('');
            $('[data-selector="IndexPage"]').html(data);
        });        
    });

    $(AddContact.Selectors.AddContactPage).on('click', AddContact.Selectors.CreateContact, function () {
        var contact = {
            FirstName: $(AddContact.Selectors.FirstName).val(),
            LastName: $(AddContact.Selectors.LastName).val(),
            PhoneNumber: $(AddContact.Selectors.PhoneNumber).val()
        };

        $.ajax({
            type: 'POST',
            url: "https://localhost:7268/api/Contacts/",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(contact),
            success: function (data) {
                debugger;
                $.get("/Home/Index", function (data) {
                    debugger;
                    $('#AddContact').html('');
                    $('[data-selector="IndexPage"]').html(data);
                });   
            }
        });
    });
});

