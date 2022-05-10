// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class AmbienteModel {
  String? id;
  String? codigoSala;
  int? tamanhoBloco;
  AmbienteModel({
    this.id,
    this.codigoSala,
    this.tamanhoBloco,
  });

  

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'codigoSala': codigoSala,
      'tamanhoBloco': tamanhoBloco,
    };
  }

  factory AmbienteModel.fromMap(Map<String, dynamic> map) {
    return AmbienteModel(
      id: map['id'] != null ? map['id'] as String : null,
      codigoSala: map['codigoSala'] != null ? map['codigoSala'] as String : null,
      tamanhoBloco: map['tamanhoBloco'] != null ? map['tamanhoBloco'] as int : null,
    );
  }

  String toJson() => json.encode(toMap());

  factory AmbienteModel.fromJson(String source) => AmbienteModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
