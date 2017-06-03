
Ext.namespace('Model');

Model.YP_PRICE = function(type){
	this.record = Ext.data.Record.create([
		{name : 'ID',mapping:'ID',type : 'string'},
		{name : 'MAKERDICID',mapping:'MAKERDICID',type : 'string'},
		{name : 'WORKID',mapping:'WORKID',type : 'string'},
		{name : 'RETAILPRICE',mapping:'RETAILPRICE',type : 'string'},
		{name : 'EDIT_TIME',mapping:'EDIT_TIME',type : 'string'},
		{name : 'VALID_FLAG',mapping:'VALID_FLAG',type : 'string'},
	]);

	this.store = new Ext.data.Store({
		proxy: new Ext.data.HttpProxy({
			method: 'GET',
			url: 'Action/'
		}),
		reader: new Ext.data.JsonReader({
			root: 'rows',
			totalProperty: 'total',
			fields: [
				{name : 'ID',mapping:'ID',type : 'string'},
				{name : 'MAKERDICID',mapping:'MAKERDICID',type : 'string'},
				{name : 'WORKID',mapping:'WORKID',type : 'string'},
				{name : 'RETAILPRICE',mapping:'RETAILPRICE',type : 'string'},
				{name : 'EDIT_TIME',mapping:'EDIT_TIME',type : 'string'},
				{name : 'VALID_FLAG',mapping:'VALID_FLAG',type : 'string'},
			]
		})
	});

	this.cm = new Ext.grid.ColumnModel([
		new Ext.grid.RowNumberer(),
			{header: 'ID', width: 80, sortable: true, dataIndex: 'ID'},
			{header: 'MAKERDICID', width: 80, sortable: true, dataIndex: 'MAKERDICID'},
			{header: 'WORKID', width: 80, sortable: true, dataIndex: 'WORKID'},
			{header: 'RETAILPRICE', width: 80, sortable: true, dataIndex: 'RETAILPRICE'},
			{header: 'EDIT_TIME', width: 80, sortable: true, dataIndex: 'EDIT_TIME'},
			{header: 'VALID_FLAG', width: 80, sortable: true, dataIndex: 'VALID_FLAG'},
	]);
}
