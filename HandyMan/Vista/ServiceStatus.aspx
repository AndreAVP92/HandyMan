<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ServiceStatus.aspx.cs" Inherits="Vista.ServiceStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round">
<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

<div class="container" id="containerServiceStates">		
       <div class="table-wrapper">
           <div class="table-title">
               <div class="row">
                   <div class="col-sm-6">
					<h2>Administrar <b>Estados del Servicio</b></h2>
				</div>
				<div class="col-sm-6">
					<a href="#addServiceStatesModal" class="btn btn-success" data-toggle="modal" style="background:#9ACD32"><i class="material-icons">&#xE147;</i> <span>Agregar</span></a>					
				</div>
               </div>				
           </div>
		<div class="onoffswitch">
               <input type="checkbox" name="onoffswitch" class="onoffswitch-checkbox" id="estados" checked="checked">
               <label class="onoffswitch-label" for="estados">
                   <span class="onoffswitch-inner"></span>
                   <span class="onoffswitch-switch"></span>
               </label>
           </div>

           <table class="table table-striped table-hover" id="refresh">
               <thead>
                   <tr>
					<th>Id</th>
                       <th>Descripción</th>
                       <th>Estado</th>
					<th>Acción</th>
                   </tr>
               </thead>
			<tbody id="body_servicestates">
                   
			</tbody>				
           </table>
		<div class="clearfix">
               <div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
               <ul class="pagination">
                   <li class="disabled"><a href="#">Previous</a></li>         
				<li class="active"><a href="#" class="page-link">1</a></li>
				<li > <a href="#" class="page-link">2</a> </li>
				<li > <a href="#" class="page-link">3</a> </li>
				<li > <a href="#" class="page-link">4</a> </li>
                   <li class="page-item"><a href="#" class="page-link">Next</a></li>
               </ul>
           </div>
       </div>
   </div>
<!-- Add Modal HTML -->
<div id="addServiceStatesModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
			<div class="modal-header">						
				<h4 class="modal-title">Agregar Estado del Servicio</h4>
				<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
			</div>
			<div class="modal-body">					
				<div class="form-group">
					<label>Descripción</label>
					<input type="text" id="add_inputDescription" class="form-control" required>
				</div>						
			</div>
			<div class="modal-footer">
				<input type="button" id="buttonCancel"  class="btn btn-default" data-dismiss="modal" value="Cancelar">
				<input type="button" id="buttonSaveServiceStates" class="btn btn-success" value="Agregar" style="background:#9ACD32">
			</div>
		</div>
	</div>
</div>
<!-- Edit Modal HTML -->
<div id="editServiceStatesModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
				<div class="modal-header">						
					<h4 class="modal-title">Editar Medio de Pago</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">					
					<div class="form-group">
						<label>Id</label>
						<input type="text" id="edit_inputId" class="form-control" disabled>
						<label>Descripción</label>
						<input type="text" id="edit_inputDescription" class="form-control" required>
						<label>Estado</label><br />
						<button type="button" Id="button_onoff" class="btn btn-danger btn-sm">Deshabilitar</button>
					</div>					
				</div>
				<div class="modal-footer">
					<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
					<input type="button" id="buttonEditPayment" class="btn btn-info" value="Save"/>
				</div>
		</div>
	</div>
</div>
<!-- Delete Modal HTML -->
<div id="deleteServiceStatesModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">			
			<div class="modal-header">						
				<h4 class="modal-title">Eliminar Estados del Servicio</h4>
				<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
			</div>
			<div class="modal-body">					
				<p>Are you sure you want to delete these Records?</p>
				<p class="text-warning"><small>This action cannot be undone.</small></p>
			</div>
			<div class="modal-footer">
				<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
				<input type="button" id="buttonDeleteServiceStates" class="btn btn-danger" value="Delete">				
			</div>
		</div>
	</div>
</div>

</asp:Content>
