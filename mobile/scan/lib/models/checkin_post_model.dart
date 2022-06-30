// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class CheckinsPostModel {
  int quantidadeBlocos;
  String ambienteId;

  CheckinsPostModel(
      {required this.quantidadeBlocos,
      required this.ambienteId});

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'quantidadeBlocos': quantidadeBlocos,
      'ambienteId': ambienteId,
      
    };
  }

  factory CheckinsPostModel.fromMap(Map<String, dynamic> map) {
    return CheckinsPostModel(
      quantidadeBlocos: map['quantidadeBlocos'] as int,
      ambienteId: map['ambienteId'] as String,
      
    );
  }

  String toJson() => json.encode(toMap());

  factory CheckinsPostModel.fromJson(String source) =>
      CheckinsPostModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
