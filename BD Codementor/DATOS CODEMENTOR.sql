SET DATEFORMAT 'YMD' -- VISTO EN SCRIPT DE EXAMEN INTEGRADOR DE LABO 3

--USUARIOS
INSERT INTO USUARIOS(EMAIL,PASS,ES_ADMIN) VALUES('user@user.com','user',0) , ('admin@admin.com','admin',1)
GO
--LENGUAJES
INSERT INTO LENGUAJES(NOMBRE)VALUES ('C#'),('JAVA'),('JAVASCRIPT'),('C++'),('PYTHON'),('CSS'),('HTML'),('ANGULAR'),('REACT'),('TYPESCRIPT')
GO
--CATEGORIAS

INSERT INTO CATEGORIAS(NOMBRE) VALUES ('DESARROLLO WEB'),('BACK END'),('FRONT END'),('.NET'),('FULL STACK'),('ANALISIS DE DATOS')
GO
-- CURSOS

INSERT INTO CURSOS (NOMBRE,DESCRIPCION,REQUISITOS,IMPORTE,URL_PORTADA,IDCATEGORIA )
VALUES 
('CURSO DE C#','En este curso aprenderas las bases y fundamentos de C#. Lograras Realizar proyectos de Escritorio y Tipo Web con .Net',
'No se requieren requisitos previos',10000,'https://cdn.openwebinars.net/media/facebook-ads-c-sharp-principiantes.jpg',4),
('ANGULAR DE CERO A AVANZADO',
'Angular es un framework para desarrollo de aplicaciones de todo tipo, por defecto genera aplicaciones web muy poderosas y robustas, y si se mezcla con otras tecnologías, puedes hacer aplicaciones móviles y de escritorio también con el mismo código.',
'HTML-CSS-JS BASICOS',5000,
'https://upload.wikimedia.org/wikipedia/commons/thumb/c/cf/Angular_full_color_logo.svg/1200px-Angular_full_color_logo.svg.png',1),
('CSS ,HTML Y JAVASCRIPT PARA PRINCIPIANTES','En este curso aprenderas todo lo necesario para introducirte al mundo del desarrollo web',
'No se requieren requisitos previos',3000,'https://fiverr-res.cloudinary.com/images/q_auto,f_auto/gigs/336072064/original/6428f500c92850befd71d58abf50780bff0bc89f/develop-html-css-javascript-web-pages-for-front-end.jpg',
1),
('REACT','Aprende los fundamentos de React, la biblioteca de JavaScript más popular para construir interfaces de usuario modernas y dinámicas. Este curso te guiará a través de la creación de componentes reutilizables, el manejo del estado y la gestión de datos, permitiéndote desarrollar aplicaciones web rápidas y escalables',
'Conocimientos de Javascript necesarios',9000,'https://lh4.googleusercontent.com/rV7j2cc-_2vwsVxR26zKDYwnwLgDk3k8dXkKwm7ZPDQonHc1dyfLe8E0qOgb4lpWRujGY6W-XtkGLROQ6VxGolTsfFSqJFAq8VhxbTDDxMo6cdkIeDsYQ3LPWzk_Tzj4-ZDIS7hMhGeTMIh6bO_s6HV9YtX4ogfgvmfsPwfQCyFR9WAOUacD9ouzjQ',
 3),
('JAVASCRIPT ','Este curso está diseñado para proporcionar una comprensión sólida de JavaScript, el lenguaje de programación esencial para el desarrollo web. A lo largo del curso, aprenderás desde los conceptos básicos hasta las técnicas avanzadas, permitiéndote construir aplicaciones web interactivas y dinámicas. Cubriremos temas como la manipulación del DOM, el manejo de eventos, las promesas y las APIs, y trabajaremos en proyectos prácticos para aplicar tus conocimientos en situaciones del mundo real.',
'No se requieren requisitos previos',15000,
'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/1200px-Unofficial_JavaScript_logo_2.svg.png',
1),
('PROGRAMACION EN PYTHON','Este curso integral de Python está diseñado para llevarte desde los conceptos básicos de la programación hasta habilidades avanzadas en uno de los lenguajes más versátiles y demandados en la industria. Python es conocido por su simplicidad y legibilidad, lo que lo hace ideal tanto para principiantes como para programadores experimentados. A lo largo del curso, aprenderás sobre la sintaxis básica de Python, estructuras de datos, programación orientada a objetos, manejo de archivos, y trabajarás con bibliotecas populares como Pandas, NumPy, y Flask. También realizaremos proyectos prácticos para aplicar tus conocimientos en el desarrollo de aplicaciones reales, análisis de datos y automatización de tareas.',
'No se requieren requisitos previos',10000,
'https://s3-us-west-2.amazonaws.com/devcodepro/media/blog/por-que-aprender-python.png',2
)

GO

--LENGUAJES X CURSO
INSERT INTO LENGUAJESXCURSO(IDLENGUAJE,IDCURSO)
VALUES (1,1),(6,2),(10,2),(8,2),(7,2),(6,3),(7,3),(3,3),
 (9,4),(6,4),(3,4),(3,5),(5,5)
GO
-- Unidades  C#
INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES
(1, 'Introducción a C#', 'Fundamentos y sintaxis básica de C#', 1),
(2, 'Programación Orientada a Objetos en C#', 'Clases, objetos, herencia y polimorfismo', 1),
(3, 'Colecciones y Genéricos', 'Uso de colecciones y tipos genéricos en C#', 1),
(4, 'Manejo de Excepciones', 'Cómo manejar errores y excepciones en C#', 1),
(5, 'Aplicaciones Web con .NET', 'Desarrollo de aplicaciones web utilizando ASP.NET', 1);

-- Unidades  Angular
INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES
(1, 'Introducción a Angular', 'Conceptos básicos y configuración del entorno', 2),
(2, 'Componentes y Templates', 'Creación y uso de componentes y templates en Angular', 2),
(3, 'Data Binding y Directivas', 'Manejo de datos y uso de directivas en Angular', 2),
(4, 'Servicios y Dependency Injection', 'Creación y uso de servicios en Angular', 2),
(5, 'Rutas y Navegación', 'Gestión de rutas y navegación en aplicaciones Angular', 2);

-- Unidades CSS HTML JS
INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES
(1, 'Fundamentos de HTML', 'Estructura básica de documentos HTML', 3),
(2, 'Estilizado con CSS', 'Uso de CSS para estilizar páginas web', 3),
(3, 'Introducción a JavaScript', 'Fundamentos de JavaScript y programación básica', 3),
(4, 'Interactividad con JavaScript', 'Uso de JavaScript para añadir interactividad a páginas web', 3),
(5, 'Proyectos Prácticos', 'Desarrollo de proyectos prácticos utilizando HTML, CSS y JavaScript', 3);

--  React
INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES
(1, 'Introducción a React', 'Fundamentos y configuración del entorno de React', 4),
(2, 'Componentes y Props', 'Creación y uso de componentes y props en React', 4),
(3, 'Estado y Ciclo de Vida', 'Manejo del estado y ciclo de vida de componentes en React', 4),
(4, 'Hooks', 'Uso de hooks en React para gestionar estado y efectos', 4),
(5, 'Proyecto Final', 'Desarrollo de un proyecto completo utilizando React', 4);

--  JavaScript
INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES
(1, 'Introducción a JavaScript', 'Fundamentos y sintaxis básica de JavaScript', 5),
(2, 'Manipulación del DOM', 'Cómo interactuar con el Document Object Model (DOM)', 5),
(3, 'Eventos en JavaScript', 'Manejo de eventos y creación de interactividad', 5),
(4, 'Promesas y Async/Await', 'Gestión de operaciones asíncronas con promesas y async/await', 5),
(5, 'APIs y Fetch', 'Consumo de APIs y manejo de datos externos', 5);

GO
--  Python
INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES
(1, 'Introducción a Python', 'Fundamentos y sintaxis básica de Python', 6),
(2, 'Estructuras de Datos', 'Uso de listas, tuplas, diccionarios y conjuntos en Python', 6),
(3, 'Programación Orientada a Objetos', 'Clases y objetos en Python', 6),
(4, 'Manejo de Archivos', 'Lectura y escritura de archivos en Python', 6),
(5, 'Proyectos Prácticos', 'Desarrollo de proyectos prácticos utilizando Python', 6);


GO
-- Clases curso de C#
INSERT INTO CLASES (IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO) VALUES
(1, 1, 'Introducción y configuración del entorno', 30, 'https://www.youtube.com/watch?v=example1'),
(1, 2, 'Sintaxis básica de C#', 45, 'https://www.youtube.com/watch?v=example2'),
(2, 1, 'Conceptos de programación orientada a objetos', 60, 'https://www.youtube.com/watch?v=example3'),
(2, 2, 'Clases y objetos en C#', 40, 'https://www.youtube.com/watch?v=example4'),
(3, 1, 'Uso de colecciones en C#', 35, 'https://www.youtube.com/watch?v=example5'),
(3, 2, 'Tipos genéricos en C#', 50, 'https://www.youtube.com/watch?v=example6'),
(4, 1, 'Introducción al manejo de excepciones', 25, 'https://www.youtube.com/watch?v=example7'),
(4, 2, 'Manejo avanzado de excepciones', 45, 'https://www.youtube.com/watch?v=example8'),
(5, 1, 'Desarrollo de aplicaciones web con .NET', 60, 'https://www.youtube.com/watch?v=example9'),
(5, 2, 'Proyecto final: Aplicación web con .NET', 90, 'https://www.youtube.com/watch?v=example10');
GO
-- Clases Angular
INSERT INTO CLASES (IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO) VALUES
(6, 1, 'Introducción a Angular y configuración del entorno', 50, 'https://www.youtube.com/watch?v=example11'),
(6, 2, 'Primeros pasos con Angular', 40, 'https://www.youtube.com/watch?v=example12'),
(7, 1, 'Creación de componentes en Angular', 45, 'https://www.youtube.com/watch?v=example13'),
(7, 2, 'Uso de templates en Angular', 35, 'https://www.youtube.com/watch?v=example14'),
(8, 1, 'Data binding en Angular', 30, 'https://www.youtube.com/watch?v=example15'),
(8, 2, 'Directivas en Angular', 40, 'https://www.youtube.com/watch?v=example16'),
(9, 1, 'Creación de servicios en Angular', 50, 'https://www.youtube.com/watch?v=example17'),
(9, 2, 'Uso de Dependency Injection', 45, 'https://www.youtube.com/watch?v=example18'),
(10, 1, 'Gestión de rutas en Angular', 35, 'https://www.youtube.com/watch?v=example19'),
(10, 2, 'Navegación en aplicaciones Angular', 40, 'https://www.youtube.com/watch?v=example20');
GO
--  CSS, HTML y JavaScript
INSERT INTO CLASES (IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO) VALUES
(11, 1, 'Estructura básica de HTML', 30, 'https://www.youtube.com/watch?v=example21'),
(11, 2, 'Etiquetas y atributos en HTML', 35, 'https://www.youtube.com/watch?v=example22'),
(12, 1, 'Introducción a CSS', 45, 'https://www.youtube.com/watch?v=example23'),
(12, 2, 'Selectores y propiedades en CSS', 40, 'https://www.youtube.com/watch?v=example24'),
(13, 1, 'Fundamentos de JavaScript', 50, 'https://www.youtube.com/watch?v=example25'),
(13, 2, 'Variables y operadores en JavaScript', 45, 'https://www.youtube.com/watch?v=example26'),
(14, 1, 'Manipulación del DOM con JavaScript', 55, 'https://www.youtube.com/watch?v=example27'),
(14, 2, 'Eventos y funciones en JavaScript', 50, 'https://www.youtube.com/watch?v=example28'),
(15, 1, 'Proyecto práctico: Página web básica', 70, 'https://www.youtube.com/watch?v=example29'),
(15, 2, 'Mejorando la interactividad', 60, 'https://www.youtube.com/watch?v=example30');

GO
-- Clases para el curso de React
INSERT INTO CLASES (IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO) VALUES
(16, 1, 'Fundamentos de React y JSX', 40, 'https://www.youtube.com/watch?v=example31'),
(16, 2, 'Configuración del entorno de desarrollo', 35, 'https://www.youtube.com/watch?v=example32'),
(17, 1, 'Creación de componentes en React', 50, 'https://www.youtube.com/watch?v=example33'),
(17, 2, 'Uso de props en React', 45, 'https://www.youtube.com/watch?v=example34'),
(18, 1, 'Gestión del estado en React', 55, 'https://www.youtube.com/watch?v=example35'),
(18, 2, 'Ciclo de vida de componentes', 50, 'https://www.youtube.com/watch?v=example36'),
(19, 1, 'Uso de hooks en React', 60, 'https://www.youtube.com/watch?v=example37'),
(19, 2, 'Hooks personalizados', 55, 'https://www.youtube.com/watch?v=example38'),
(20, 1, 'Proyecto final: Aplicación con React', 90, 'https://www.youtube.com/watch?v=example39'),
(20, 2, 'Mejoras y optimización', 80, 'https://www.youtube.com/watch?v=example40');

GO
-- Clases  JavaScript
INSERT INTO CLASES (IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO) VALUES
(21, 1, 'Introducción a JavaScript', 30, 'https://www.youtube.com/watch?v=example41'),
(21, 2, 'Sintaxis básica de JavaScript', 35, 'https://www.youtube.com/watch?v=example42'),
(22, 1, 'Manipulación del DOM', 45, 'https://www.youtube.com/watch?v=example43'),
(22, 2, 'Creación y eliminación de elementos', 40, 'https://www.youtube.com/watch?v=example44'),
(23, 1, 'Eventos en JavaScript', 50, 'https://www.youtube.com/watch?v=example45'),
(23, 2, 'Manejo de eventos avanzados', 45, 'https://www.youtube.com/watch?v=example46'),
(24, 1, 'Introducción a las promesas', 55, 'https://www.youtube.com/watch?v=example47'),
(24, 2, 'Async/Await en JavaScript', 50, 'https://www.youtube.com/watch?v=example48'),
(25, 1, 'Consumo de APIs con Fetch', 60, 'https://www.youtube.com/watch?v=example49'),
(25, 2, 'Manejo de datos externos', 55, 'https://www.youtube.com/watch?v=example50');

GO
-- Clases  en Python
INSERT INTO CLASES (IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO) VALUES
(26, 1, 'Introducción a Python', 30, 'https://www.youtube.com/watch?v=example51'),
(26, 2, 'Sintaxis básica de Python', 35, 'https://www.youtube.com/watch?v=example52'),
(27, 1, 'Listas y tuplas en Python', 45, 'https://www.youtube.com/watch?v=example53'),
(27, 2, 'Diccionarios y conjuntos en Python', 40, 'https://www.youtube.com/watch?v=example54'),
(28, 1, 'Programación orientada a objetos', 50, 'https://www.youtube.com/watch?v=example55'),
(28, 2, 'Herencia y polimorfismo', 45, 'https://www.youtube.com/watch?v=example56'),
(29, 1, 'Manejo de archivos en Python', 55, 'https://www.youtube.com/watch?v=example57'),
(29, 2, 'Lectura y escritura de archivos', 50, 'https://www.youtube.com/watch?v=example58'),
(30, 1, 'Proyecto práctico: Aplicación en Python', 70, 'https://www.youtube.com/watch?v=example59'),
(30, 2, 'Mejoras y optimización', 60, 'https://www.youtube.com/watch?v=example60');

GO
--INSCRIPCIONES

INSERT INTO INSCRIPCIONES (IDCURSO, IDUSUARIO,HABILITADA) VALUES
(1, 1,1),
(2, 1,1),
(3, 1,1),
(4, 1,1),
(5, 1,1);

--RESEÑAS
-- C#
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(1, 1, 4, 'Excelente curso, aprendí mucho sobre C# y ahora me siento más seguro para desarrollar aplicaciones.'),
(2, 1, 5, 'Increíble curso, el contenido estaba muy bien organizado y los ejemplos fueron muy útiles.'),
(3, 1, 4, 'Muy buen curso para principiantes, cubre los fundamentos de C# de manera clara y concisa.');

-- CSS, HTML y JS
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(2, 3, 4, 'Buen curso introductorio, me ayudó a comprender los conceptos básicos de desarrollo web.'),
(3, 3, 3, 'El curso fue útil, pero me hubiera gustado más ejercicios prácticos para practicar.');

-- JavaScript
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(3, 5, 5, '¡Excelente curso! Aprendí mucho sobre JavaScript y ahora puedo crear aplicaciones web interactivas.'),
(1, 5, 4, 'Muy buen curso para aprender JavaScript desde cero, los ejemplos fueron muy claros y fáciles de entender.');


--PAISES
GO
INSERT INTO PAISES VALUES 
(1,'Afghanistan','AF','AFG')
,(2,'Aland Islands','AX','ALA')
,(3,'Albania','AL','ALB')
,(4,'Algeria','DZ','DZA')
,(5,'American Samoa','AS','ASM')
,(6,'Andorra','AD','AND')
,(7,'Angola','AO','AGO')
,(8,'Anguilla','AI','AIA')
,(9,'Antarctica','AQ','ATA')
,(10,'Antigua and Barbuda','AG','ATG')
,(11,'Argentina','AR','ARG')
,(12,'Armenia','AM','ARM')
,(13,'Aruba','AW','ABW')
,(14,'Australia','AU','AUS')
,(15,'Austria','AT','AUT')
,(16,'Azerbaijan','AZ','AZE')
,(17,'Bahamas','BS','BHS')
,(18,'Bahrain','BH','BHR')
,(19,'Bangladesh','BD','BGD')
,(20,'Barbados','BB','BRB')
,(21,'Belarus','BY','BLR')
,(22,'Belgium','BE','BEL')
,(23,'Belize','BZ','BLZ')
,(24,'Benin','BJ','BEN')
,(25,'Bermuda','BM','BMU')
,(26,'Bhutan','BT','BTN')
,(27,'Bolivia','BO','BOL')
,(28,'Bonaire, Sint Eustatius and Saba','BQ','BES')
,(29,'Bosnia and Herzegovina','BA','BIH')
,(30,'Botswana','BW','BWA')
,(31,'Bouvet Island','BV','BVT')
,(32,'Brazil','BR','BRA')
,(33,'British Indian Ocean Territory','IO','IOT')
,(34,'Brunei','BN','BRN')
,(35,'Bulgaria','BG','BGR')
,(36,'Burkina Faso','BF','BFA')
,(37,'Burundi','BI','BDI')
,(38,'Cambodia','KH','KHM')
,(39,'Cameroon','CM','CMR')
,(40,'Canada','CA','CAN')
,(41,'Cape Verde','CV','CPV')
,(42,'Cayman Islands','KY','CYM')
,(43,'Central African Republic','CF','CAF')
,(44,'Chad','TD','TCD')
,(45,'Chile','CL','CHL')
,(46,'China','CN','CHN')
,(47,'Christmas Island','CX','CXR')
,(48,'Cocos (Keeling) Islands','CC','CCK')
,(49,'Colombia','CO','COL')
,(50,'Comoros','KM','COM')
,(51,'Congo','CG','COG')
,(52,'Cook Islands','CK','COK')
,(53,'Costa Rica','CR','CRI')
,(54,'Ivory Coast','CI','CIV')
,(55,'Croatia','HR','HRV')
,(56,'Cuba','CU','CUB')
,(57,'Curacao','CW','CUW')
,(58,'Cyprus','CY','CYP')
,(59,'Czech Republic','CZ','CZE')
,(60,'Democratic Republic of the Congo','CD','COD')
,(61,'Denmark','DK','DNK')
,(62,'Djibouti','DJ','DJI')
,(63,'Dominica','DM','DMA')
,(64,'Dominican Republic','DO','DOM')
,(65,'Ecuador','EC','ECU')
,(66,'Egypt','EG','EGY')
,(67,'El Salvador','SV','SLV')
,(68,'Equatorial Guinea','GQ','GNQ')
,(69,'Eritrea','ER','ERI')
,(70,'Estonia','EE','EST')
,(71,'Ethiopia','ET','ETH')
,(72,'Falkland Islands (Malvinas)','FK','FLK')
,(73,'Faroe Islands','FO','FRO')
,(74,'Fiji','FJ','FJI')
,(75,'Finland','FI','FIN')
,(76,'France','FR','FRA')
,(77,'French Guiana','GF','GUF')
,(78,'French Polynesia','PF','PYF')
,(79,'French Southern Territories','TF','ATF')
,(80,'Gabon','GA','GAB')
,(81,'Gambia','GM','GMB')
,(82,'Georgia','GE','GEO')
,(83,'Germany','DE','DEU')
,(84,'Ghana','GH','GHA')
,(85,'Gibraltar','GI','GIB')
,(86,'Greece','GR','GRC')
,(87,'Greenland','GL','GRL')
,(88,'Grenada','GD','GRD')
,(89,'Guadaloupe','GP','GLP')
,(90,'Guam','GU','GUM')
,(91,'Guatemala','GT','GTM')
,(92,'Guernsey','GG','GGY')
,(93,'Guinea','GN','GIN')
,(94,'Guinea-Bissau','GW','GNB')
,(95,'Guyana','GY','GUY')
,(96,'Haiti','HT','HTI')
,(97,'Heard Island and McDonald Islands','HM','HMD')
,(98,'Honduras','HN','HND')
,(99,'Hong Kong','HK','HKG')
,(100,'Hungary','HU','HUN')
,(101,'Iceland','IS','ISL')
,(102,'India','IN','IND')
,(103,'Indonesia','ID','IDN')
,(104,'Iran','IR','IRN')
,(105,'Iraq','IQ','IRQ')
,(106,'Ireland','IE','IRL')
,(107,'Isle of Man','IM','IMN')
,(108,'Israel','IL','ISR')
,(109,'Italy','IT','ITA')
,(110,'Jamaica','JM','JAM')
,(111,'Japan','JP','JPN')
,(112,'Jersey','JE','JEY')
,(113,'Jordan','JO','JOR')
,(114,'Kazakhstan','KZ','KAZ')
,(115,'Kenya','KE','KEN')
,(116,'Kiribati','KI','KIR')
,(117,'Kosovo','XK','---')
,(118,'Kuwait','KW','KWT')
,(119,'Kyrgyzstan','KG','KGZ')
,(120,'Laos','LA','LAO')
,(121,'Latvia','LV','LVA')
,(122,'Lebanon','LB','LBN')
,(123,'Lesotho','LS','LSO')
,(124,'Liberia','LR','LBR')
,(125,'Libya','LY','LBY')
,(126,'Liechtenstein','LI','LIE')
,(127,'Lithuania','LT','LTU')
,(128,'Luxembourg','LU','LUX')
,(129,'Macao','MO','MAC')
,(130,'Macedonia','MK','MKD')
,(131,'Madagascar','MG','MDG')
,(132,'Malawi','MW','MWI')
,(133,'Malaysia','MY','MYS')
,(134,'Maldives','MV','MDV')
,(135,'Mali','ML','MLI')
,(136,'Malta','MT','MLT')
,(137,'Marshall Islands','MH','MHL')
,(138,'Martinique','MQ','MTQ')
,(139,'Mauritania','MR','MRT')
,(140,'Mauritius','MU','MUS')
,(141,'Mayotte','YT','MYT')
,(142,'Mexico','MX','MEX')
,(143,'Micronesia','FM','FSM')
,(144,'Moldava','MD','MDA')
,(145,'Monaco','MC','MCO')
,(146,'Mongolia','MN','MNG')
,(147,'Montenegro','ME','MNE')
,(148,'Montserrat','MS','MSR')
,(149,'Morocco','MA','MAR')
,(150,'Mozambique','MZ','MOZ')
,(151,'Myanmar (Burma)','MM','MMR')
,(152,'Namibia','NA','NAM')
,(153,'Nauru','NR','NRU')
,(154,'Nepal','NP','NPL')
,(155,'Netherlands','NL','NLD')
,(156,'New Caledonia','NC','NCL')
,(157,'New Zealand','NZ','NZL')
,(158,'Nicaragua','NI','NIC')
,(159,'Niger','NE','NER')
,(160,'Nigeria','NG','NGA')
,(161,'Niue','NU','NIU')
,(162,'Norfolk Island','NF','NFK')
,(163,'North Korea','KP','PRK')
,(164,'Northern Mariana Islands','MP','MNP')
,(165,'Norway','NO','NOR')
,(166,'Oman','OM','OMN')
,(167,'Pakistan','PK','PAK')
,(168,'Palau','PW','PLW')
,(169,'Palestine','PS','PSE')
,(170,'Panama','PA','PAN')
,(171,'Papua New Guinea','PG','PNG')
,(172,'Paraguay','PY','PRY')
,(173,'Peru','PE','PER')
,(174,'Phillipines','PH','PHL')
,(175,'Pitcairn','PN','PCN')
,(176,'Poland','PL','POL')
,(177,'Portugal','PT','PRT')
,(178,'Puerto Rico','PR','PRI')
,(179,'Qatar','QA','QAT')
,(180,'Reunion','RE','REU')
,(181,'Romania','RO','ROU')
,(182,'Russia','RU','RUS')
,(183,'Rwanda','RW','RWA')
,(184,'Saint Barthelemy','BL','BLM')
,(185,'Saint Helena','SH','SHN')
,(186,'Saint Kitts and Nevis','KN','KNA')
,(187,'Saint Lucia','LC','LCA')
,(188,'Saint Martin','MF','MAF')
,(189,'Saint Pierre and Miquelon','PM','SPM')
,(190,'Saint Vincent and the Grenadines','VC','VCT')
,(191,'Samoa','WS','WSM')
,(192,'San Marino','SM','SMR')
,(193,'Sao Tome and Principe','ST','STP')
,(194,'Saudi Arabia','SA','SAU')
,(195,'Senegal','SN','SEN')
,(196,'Serbia','RS','SRB')
,(197,'Seychelles','SC','SYC')
,(198,'Sierra Leone','SL','SLE')
,(199,'Singapore','SG','SGP')
,(200,'Sint Maarten','SX','SXM')
,(201,'Slovakia','SK','SVK')
,(202,'Slovenia','SI','SVN')
,(203,'Solomon Islands','SB','SLB')
,(204,'Somalia','SO','SOM')
,(205,'South Africa','ZA','ZAF')
,(206,'South Georgia and the South Sandwich Islands','GS','SGS')
,(207,'South Korea','KR','KOR')
,(208,'South Sudan','SS','SSD')
,(209,'Spain','ES','ESP')
,(210,'Sri Lanka','LK','LKA')
,(211,'Sudan','SD','SDN')
,(212,'Suriname','SR','SUR')
,(213,'Svalbard and Jan Mayen','SJ','SJM')
,(214,'Swaziland','SZ','SWZ')
,(215,'Sweden','SE','SWE')
,(216,'Switzerland','CH','CHE')
,(217,'Syria','SY','SYR')
,(218,'Taiwan','TW','TWN')
,(219,'Tajikistan','TJ','TJK')
,(220,'Tanzania','TZ','TZA')
,(221,'Thailand','TH','THA')
,(222,'Timor-Leste (East Timor)','TL','TLS')
,(223,'Togo','TG','TGO')
,(224,'Tokelau','TK','TKL')
,(225,'Tonga','TO','TON')
,(226,'Trinidad and Tobago','TT','TTO')
,(227,'Tunisia','TN','TUN')
,(228,'Turkey','TR','TUR')
,(229,'Turkmenistan','TM','TKM')
,(230,'Turks and Caicos Islands','TC','TCA')
,(231,'Tuvalu','TV','TUV')
,(232,'Uganda','UG','UGA')
,(233,'Ukraine','UA','UKR')
,(234,'United Arab Emirates','AE','ARE')
,(235,'United Kingdom','GB','GBR')
,(236,'United States','US','USA')
,(237,'United States Minor Outlying Islands','UM','UMI')
,(238,'Uruguay','UY','URY')
,(239,'Uzbekistan','UZ','UZB')
,(240,'Vanuatu','VU','VUT')
,(241,'Vatican City','VA','VAT')
,(242,'Venezuela','VE','VEN')
,(243,'Vietnam','VN','VNM')
,(244,'Virgin Islands, British','VG','VGB')
,(245,'Virgin Islands, US','VI','VIR')
,(246,'Wallis and Futuna','WF','WLF')
,(247,'Western Sahara','EH','ESH')
,(248,'Yemen','YE','YEM')
,(249,'Zambia','ZM','ZMB')
,(250,'Zimbabwe','ZW','ZWE');

GO
--USUARIOS
INSERT INTO INFORMACION_USUARIO(
    IDUSUARIO,NOMBRE,APELLIDO,FECHA_NACIMIENTO,IDPAIS,CELULAR,SEXO
)
VALUES
(
 1,'USUARIO','GENERICO','2000-06-19',11,1165656596,'M'
),
(
 2,'ADMIN','GENERICO','2000-05-09',11,1189564512,'F'
)
GO
-- CURSO NRO : 1
INSERT INTO UNIDADES_FINALIZADAS (IDUNIDAD, IDUSUARIO) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1);

GO
-- 3
INSERT INTO UNIDADES_FINALIZADAS (IDUNIDAD, IDUSUARIO) VALUES
(11, 1),
(12, 1),
(13, 1),
(14, 1),
(15, 1);

GO
-- 5
INSERT INTO UNIDADES_FINALIZADAS (IDUNIDAD, IDUSUARIO) VALUES
(21, 1),
(22, 1),
(23, 1),
(24, 1)

--COMO FINALIZO TODAS UNIDADES .. GENERAMOS CERTIFICACIONES. IMPORTANTE DATOS CONSISTENTES.
GO
INSERT INTO CERTIFICACIONES (IDINSCRIPCION) VALUES (1),(5),(3)


GO

--PREGUNTAS

INSERT INTO PREGUNTAS (IDCURSO, IDUSUARIO, TITULO, CUERPO) VALUES
(1, 1, 'Optimización de rendimiento en C#', '¿Cuáles son las mejores prácticas para optimizar el rendimiento de una aplicación desarrollada en C#? ¿Hay herramientas específicas que se recomienden para este propósito?'),
(1, 1, 'Implementación de patrones de diseño en C#', '¿Cómo puedo aplicar patrones de diseño como el Singleton, el Factory Method o el Observer en mis proyectos en C#? ¿Cuáles son los beneficios de utilizar estos patrones en el desarrollo?');

GO
INSERT INTO PREGUNTAS (IDCURSO, IDUSUARIO, TITULO, CUERPO) VALUES
(2, 1, 'Optimización de rendimiento en Angular', '¿Cuáles son las mejores prácticas para optimizar el rendimiento de una aplicación Angular? ¿Hay herramientas específicas que se recomienden para este propósito?'),
(2, 1, 'Seguridad en aplicaciones Angular', '¿Cómo puedo asegurar mi aplicación Angular contra vulnerabilidades comunes como XSS, CSRF o inyección de código? ¿Qué prácticas de seguridad se recomiendan en el desarrollo de aplicaciones Angular?');
GO
INSERT INTO PREGUNTAS (IDCURSO, IDUSUARIO, TITULO, CUERPO) VALUES
(4, 1, 'Manejo avanzado de estado en React', '¿Cuáles son las mejores prácticas para manejar el estado en aplicaciones React más grandes y complejas? ¿Hay herramientas o librerías que faciliten este proceso?'),
(4, 1, 'Integración de React con bibliotecas externas', '¿Cómo puedo integrar React con otras bibliotecas externas como Redux, React Router o Material-UI? ¿Cuáles son las consideraciones importantes a tener en cuenta al hacer esto?');


GO
-- Respuestas para la primera pregunta sobre C# (IDPREGUNTA = 1)
INSERT INTO RESPUESTAS(IDPREGUNTA, CUERPO) VALUES
(1, 'Para optimizar el rendimiento en una aplicación C#, se recomienda utilizar técnicas como el uso eficiente de la memoria, la minimización de operaciones costosas, y la implementación de algoritmos y estructuras de datos eficientes. Puedes utilizar herramientas como Visual Studio Profiler para identificar cuellos de botella y áreas de mejora en tu código.');

-- Respuestas para la segunda pregunta sobre C# (IDPREGUNTA = 2)
INSERT INTO RESPUESTAS(IDPREGUNTA, CUERPO) VALUES
(2, 'Puedes implementar patrones de diseño como Singleton, Factory Method y Observer en tus proyectos C# para mejorar la modularidad, reutilización y mantenibilidad del código. Estos patrones proporcionan soluciones probadas para problemas comunes de diseño de software.');

-- Respuestas para la primera pregunta sobre Angular (IDPREGUNTA = 3)
INSERT INTO RESPUESTAS(IDPREGUNTA, CUERPO) VALUES
(3, 'Para optimizar el rendimiento en una aplicación Angular, es importante seguir prácticas como la reducción de la carga inicial, el uso eficiente de directivas y componentes, y la implementación de estrategias de cambio de detección adecuadas. Herramientas como Angular CLI y Google Lighthouse pueden ayudar en la identificación de áreas de mejora.');

-- Respuestas para la segunda pregunta sobre Angular (IDPREGUNTA = 4)
INSERT INTO RESPUESTAS(IDPREGUNTA, CUERPO) VALUES
(4, 'Para asegurar una aplicación Angular contra vulnerabilidades comunes, es importante implementar prácticas de seguridad como la validación de entrada de usuario, la prevención de ataques de XSS y CSRF, y la implementación de políticas de seguridad de contenido. También se recomienda utilizar herramientas como Angular Security Scanner para identificar posibles vulnerabilidades.');

-- Respuestas para la primera pregunta sobre React (IDPREGUNTA = 5)
INSERT INTO RESPUESTAS(IDPREGUNTA, CUERPO) VALUES
(5, 'Para manejar el estado en aplicaciones React más grandes y complejas, se recomienda utilizar patrones como el patrón contenedor/componente, el uso de context API, y la separación de la lógica de negocio del componente de la presentación. Herramientas como Redux pueden facilitar la gestión del estado en aplicaciones más grandes.');

-- Respuestas para la segunda pregunta sobre React (IDPREGUNTA = 6)
INSERT INTO RESPUESTAS(IDPREGUNTA, CUERPO) VALUES
(6, 'Para integrar React con bibliotecas externas como Redux, React Router o Material-UI, puedes seguir las documentaciones y guías proporcionadas por cada biblioteca. Es importante tener en cuenta las consideraciones de compatibilidad y rendimiento al integrar estas bibliotecas en tu aplicación React.');

GO 
--RESEÑAS
--REACT
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(4, 4, 5, 'Muy buen curso para aprender React !! Me encanto!');
-- C#
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(1, 1, 4, 'Excelente curso, aprendí mucho sobre C# y ahora me siento más seguro para desarrollar aplicaciones.');

-- CSS, HTML y JS
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(3, 3, 1, 'El curso fue útil, pero me hubiera gustado más ejercicios prácticos para practicar CSS. Como soy malo pongo un 1.');

-- JavaScript
INSERT INTO RESEÑAS(IDINSCRIPCION, IDCURSO, PUNTAJE, DESCRIPCION) VALUES
(5, 5, 4, 'Muy buen curso para aprender JavaScript desde cero, los ejemplos fueron muy claros y fáciles de entender.');

UPDATE CLASES SET URL_VIDEO ='https://www.youtube.com/watch?v=8AGLjHziXho' WHERE NUMERO =1
UPDATE CLASES SET URL_VIDEO='https://www.youtube.com/watch?v=IAvZjI9FHSM' WHERE NUMERO=2
