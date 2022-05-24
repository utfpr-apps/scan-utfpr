import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:http/retry.dart';
import 'package:scan/models/ambientes_model.dart';

import '../models/checkin_post_model.dart';

class API {
  Future<AmbienteModel> hasAmbiente(String ambienteId) async {
    final client = RetryClient(http.Client());
    late String _json;

    List<AmbienteModel> _ambientesList = [];
    try {
      _json = await client.read(Uri.parse(
          'https://utfpr-scan.herokuapp.com/api/Ambientes/$ambienteId'));

      return AmbienteModel.fromMap(await json.decode(_json));
    } catch (e) {
      print("erro: $e");
    } finally {
      client.close();
    }
    return AmbienteModel();
  }
  /*
  Future<bool> hasAmbiente(String codigoSala) async {
    final client = RetryClient(http.Client());
    late String _json;

    List<AmbienteModel> _ambientesList = [];
    try {
      _json = await client
          .read(Uri.parse('https://utfpr-scan.herokuapp.com/api/Ambientes'));

      List teste = await json.decode(_json);

      for (var item in teste) {
        if (codigoSala == AmbienteModel.fromMap(item).codigoSala) {
          return true;
        }
      }
    } finally {
      client.close();
    }
    return false;
  }
  */

  Future<http.Response> login(AmbienteModel ambiente) {
    return http.post(
      Uri.parse('https://utfpr-scan.herokuapp.com/api/Ambientes'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: ambiente.toJson(),
    );
  }

  Future<CheckinsPostModel> toCheckIn(CheckinsPostModel ambiente) async {
    final response = await http.post(
      Uri.parse('https://utfpr-scan.herokuapp.com/api/Ambientes'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: ambiente.toJson(),
    );
    if (response.statusCode == 200) {
      // If the server did return a 201 CREATED response,
      // then parse the JSON.
      return CheckinsPostModel.fromJson(jsonDecode(response.body));
    } else {
      // If the server did not return a 201 CREATED response,
      // then throw an exception.
      throw Exception('Failed to create album.');
    }
  }
}
