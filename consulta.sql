						 
				
Select DATEDIFF(YEAR,e.fecha_contrato,GETDATE())
-(CASE
   WHEN DATEADD(YY,DATEDIFF(YEAR,e.fecha_contrato,GETDATE()),e.fecha_contrato)>GETDATE() THEN
      1
   ELSE
      0 
   END) as Años_Trabajados,e.sueldo_liquido, a.nombre,fam.tramo, e.sueldo_base,ben.Annos_Antiguedad,e.fecha_contrato,h.total_haberes,h.bono,h.hora_extra,h.monto_familiar,h.movilizacion,h.rut_empleado,d.descuento_afp,d.descuento_salud,d.seguro_cesantia,d.seguro_vida,d.total_descuentos
from Empleado e left join Afp a on e.afp_id = a.Id 
                         left join Haberes h on e.rut = h.rut_empleado
						 left join Descuento d on e.rut = d.rut_empleado
						 left join Asignacion_familiar fam on e.asignacion_id = fam.Id
						 left join Beneficio_Antiguedad ben on ben.Id = e.antiguedad_id;

						 select sueldo_base, nombre from Empleado;