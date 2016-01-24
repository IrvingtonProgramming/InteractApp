
// Use Parse.Cloud.define to define as many cloud functions as you want.
// For example:
Parse.Cloud.beforeSave("Event", function(request, response) {
  uri = request.object.get("ImageUri");

  Parse.Cloud.httpRequest({
    method: 'HEAD',
    url: uri,
  }).then(function(httpResponse) {
    if(httpResponse.status == 404 || httpResponse.headers['Content-Type'].substring(0,6) != "image/") {
      request.object.set("ImageUri", "invalid");
    }
  }, function(httpResponse) {
    request.object.set("ImageUri", "invalid");
  });

  area = String(request.object.get("Areas")[0]);
  school = request.object.get("School");

  var area_to_school = {
	"1":
	[
		"ACLC",
		"Alameda High",
		"ASTI",
		"Encinal High",
		"Nea",
		"Oakland High",
		"Oakland Tech",
		"Skyline",
		"St. Joes",
		"Head Royce",
		"Oakland Charter"
	],
	"2":
	[
		"Arroyo",
		"Castro Valley",
		"Hayward",
		"Kipp",
		"LPS",
		"Moreau",
		"Mt. Eden",
		"Redwood",
		"San Leandro",
		"Canyon Middle School"
	],
	"3":
	[
		"Amador Valley",
		"Dublin High",
		"Foothill",
		"Granada",
		"Hart Middle School",
		"Livermore",
		"Livermore Valley Charter Prep",
		"Pleasanton Middle School",
		"Valley Christian"
	],
	"4":
	[
		"American High",
		"Fremont Christian",
		"James Logan",
		"Newark Memorial"
	],
	"5":
	[
		"Alsion Ohlone Montessori",
		"Horner Jr. High",
		"Irvington High School",
		"John F. Kennedy",
		"Mission San Jose",
		"Robertson",
		"Washington"
	],
	"6":
	[
		"Independence",
		"James Lick",
		"Milpitas",
		"Mt. Pleasant",
		"Piedmont Hills",
		"Summit Rainier"
	],
	"7":
	[
		"Archbishop Mitty",
		"Bellarmine",
		"Brenham",
		"Gunderson",
		"Harker",
		"Lincoln",
		"Notre Dame",
		"Pioneer"
	],
	"8":
	[
		"Andrew Hill",
		"Evergreen Valley",
		"Leland",
		"Oak Grove",
		"Overfelt High",
		"Santa Teresa",
		"Silver Creek",
		"Valley Christian",
		"Yerba Buena"
	],
	"9":
	[
		"Ann Sobrato",
		"Anzar",
		"Central",
		"Christopher",
		"GECA",
		"Gilroy",
		"Live Oak",
		"Oakwood"
	],
	"10":
	[
		"Aptos",
		"Harbor",
		"Mission Hill",
		"San Lorenzo Valley",
		"Santa Cruz",
		"Scotts Valley",
		"Soquel",
		"Watsonville",
		"St. Francis",
		"Cieba"
	],
	"11":
	[
		"Adrian Wilcox",
		"Cambrian",
		"Leigh",
		"Saint Lawrence",
		"Santa Clara",
		"Saratoga",
		"Westmont",
		"Prospect",
		"Peterson MS",
		"Los Gatos"
	],
	"12":
	[
		"Cupertino",
		"Fremont",
		"Homestead",
		"Lynbrook",
		"Monta Vista",
		"Cupertino Middle School"
	],
	"13":
	[
		"German International",
		"Gunn",
		"Los Altos",
		"Mountain View",
		"Palo Alto",
		"Pinewood",
		"Saint Francis"
	]
  };

  if(area_to_school[area].indexOf(school) >= 0 || school === "All Schools") {
  	response.success();
  } else {
  	request.object.set("School", "Invalid School");
  	response.success();
  }
});
