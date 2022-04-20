class AmbienteModel {
  String? id;
  String? codigoSala;
  int? tamanhoBloco;

  AmbienteModel({this.id, this.codigoSala, this.tamanhoBloco});

  AmbienteModel.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    codigoSala = json['codigoSala'];
    tamanhoBloco = json['tamanhoBloco'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['codigoSala'] = this.codigoSala;
    data['tamanhoBloco'] = this.tamanhoBloco;
    return data;
  }
}