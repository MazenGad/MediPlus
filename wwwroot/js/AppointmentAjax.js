$(document).ready(function () {
	$('#appointmentForm').submit(function (e) {
		e.preventDefault();
		var formData = $(this).serialize();
		$.ajax({
			url: '/Home/BookAppointment',
			type: 'POST',
			data: formData,
			success: function (response, status, xhr) {
				if (xhr.status === 200) {
					$('#appointmentForm')[0].reset();

					$('#appointmentForm').append('<div class="success-message text-primary fs-2">Sent!</div>');
					$('.success-message').fadeIn().delay(2000).fadeOut();
				}
			},
			error: function () {
				alert('Error!');
			}
		});
	});
});

function GetDoctors() {
	var deptId = document.getElementById("deptId").value;
	var DocElement = document.getElementById("docId");
	DocElement.innerHTML = "";
	console.log(deptId)
	console.log(DocElement)

	$.ajax(
		{
			url: "/Home/GetDoctorsByDepartmetns?deptID=" + deptId
			, success: function (result) {
				console.log(result)
				for (let doc of result) {
					console.log(doc.id);
					console.log(doc.name);
					DocElement.innerHTML += "<option value='" + doc.id + "'>" + doc.name + "</option>";
					console.log(DocElement)

				}
				$('#docId').niceSelect('update');

			}
		});
}