# isi_project
VIDEOCLUB
Este documento explica un caso de estudio sobre la gestión de todos los videoclubs
de una cadena llamada APPV.

**Información importante sobre los videoclubs de la cadena:**

* Código del videoclub (autonumérico)
* Nombre del gerente (cadena, obligatorio y editable)
* Ciudad (cadena, obligatorio y editable)
* Calle (cadena, obligatorio y editable)
* Código postal (cadena 5 caracteres, obligatorio y editable)

**Información importante sobre las películas:**

* Código de la película (autonumérico)
* Nombre (cadena, obligatorio y editable)
* Director (cadena, opcional y editable)
* Fecha de estreno (fecha, obligatorio y editable)
* Precio de alquiler (real, obligatorio y editable)

**Información importante sobre los socios:**

* Código del socio (autonumérico)
* Nombre (cadena, obligatorio y editable)
* Edad (entero, obligatorio y editable)

**Información relevante sobre los alquileres:**

* Código del alquiler (autonumérico)
* Fecha de recogida (fecha, obligatorio y no editable)
* Fecha de devolución (fecha, obligatorio y editable)
* Total a pagar (real, obligatorio y derivado)

**Información sobre las estadísticas de los alquileres por socio:**

* Código de la estadística (autonumérico)
* Fecha de creación (fecha, obligatorio y no editable)
* Total gastado (real, obligatorio y derivado)

**Información relevante sobre el administrador:**

* Código del administrador (autonumérico)
* Nombre (cadena, obligatorio y editable)

Cuando una película se crea, se debe asignar a un videoclub. Puede haber películas que se llamen igual pero estén en distintos videoclubs. Esto son objetos distintos de la clase película, que tienen el mismo nombre pero distinto código. 

Cuando un socio se registra en el videoclub, debe proporcionar todos sus datos personales. Esto le da derecho a alquilar películas en cualquier videoclub de la cadena (no sólo en el que se haya registrado).

Cuando un socio alquila películas, se debe registrar en el sistema la fecha en la cual se ha llevado las películas y la fecha cuando las debe devolver. En un alquiler puede haber más de una película incluida. Todas las películas que forman parte de un
alquiler tendrán la misma fecha de recogida y de devolución. La fecha de devolución se puede editar y modificar, pero sólo se puede poner una fecha posterior a la actual.
El precio del alquiler se calcula como un derivado, sumando los precios de las películas que componen el alquiler.

Se desea mantener un estudio estadístico para ver lo que se gasta en la cadena de videoclubs cada uno de los socios. Para ello, una vez al mes, el administrador introduce el socio para el que desea calcular las estadísticas y el mes. Con estos datos, el sistema calcula el total de euros gastados por ese socio en ese mes. En un mes, no se puede almacenar más de un dato estadístico por socio.

**NOTA:** Para las fechas NO uses la fecha del sistema. Pide por pantalla todas las fechas necesarias para que las introduzca el usuario manualmente. 
