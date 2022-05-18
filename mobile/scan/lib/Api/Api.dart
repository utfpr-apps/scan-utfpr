import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:http/retry.dart';
import 'package:scan/models/ambientes_model.dart';

class API {
  Future<bool> hasAmbiente(String AmbienteId) async {
    final client = RetryClient(http.Client());
    late String _json;

    List<AmbienteModel> _ambientesList = [];
    try {
      _json = await client.read(Uri.parse(
          'https://utfpr-scan.herokuapp.com/api/Ambientes/$AmbienteId'));
      List teste = await json.decode(_json);
    } catch (e) {
      print("erro: $e");
    } finally {
      client.close();
    }
    return false;
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

  Future<http.Response> createAmbiente(AmbienteModel ambiente) {
    return http.post(
      Uri.parse('https://utfpr-scan.herokuapp.com/api/Ambientes'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: ambiente.toJson(),
    );
  }
}
