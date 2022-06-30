import 'dart:convert';

class NotificationModel {

  final String imagem;
  final String dataInicialAfastamento;
  final String dataFinalAfastamento;

  NotificationModel(this.imagem, this.dataInicialAfastamento, this.dataFinalAfastamento);

  Map<String, dynamic> toMap() {
    final result = <String, dynamic>{};
  
    result.addAll({'imagem': imagem});
    result.addAll({'dataInicialAfastamento': dataInicialAfastamento});
    result.addAll({'dataFinalAfastamento': dataFinalAfastamento});
  
    return result;
  }

  factory NotificationModel.fromMap(Map<String, dynamic> map) {
    return NotificationModel(
      map['imagem'] ?? '',
      map['dataInicialAfastamento'] ?? '',
      map['dataFinalAfastamento'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory NotificationModel.fromJson(String source) => NotificationModel.fromMap(json.decode(source));
}
