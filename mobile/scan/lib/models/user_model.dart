class UserModel{
  String? id;
  int? tipoUsuario;
  String? registroAcademico;
  String? token;

  UserModel({this.id, this.tipoUsuario, this.registroAcademico, this.token});

  UserModel.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    tipoUsuario = json['tipoUsuario'];
    registroAcademico = json['registroAcademico'];
    token = json['token'];
  }
  

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['tipoUsuario'] = this.tipoUsuario;
    data['registroAcademico'] = this.registroAcademico;
    data['token'] = this.token;
    return data;
  }

}